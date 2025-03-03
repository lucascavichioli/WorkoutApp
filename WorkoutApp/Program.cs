using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using WorkoutApp.Infrastructure.Persistence;
using WorkoutApp.Application.Services.Exercises;
using WorkoutApp.Application.Services.Training;
using WorkoutApp.Application.Services.TrainingPlan;
using WorkoutApp.Application.Services.TrainingExercises;
using WorkoutApp.Application.Services.TrainingPlanTraining;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(o => {
    o.DefaultApiVersion = new ApiVersion(1);
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;

    o.ApiVersionReader = new UrlSegmentApiVersionReader();
});

var environment = builder.Environment;
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddSingleton(configuration);

var conn = builder.Configuration.GetConnectionString("WorkoutConnectionSQLServer");

builder.Services.AddDbContext<WorkoutAppContext>(opts =>
    opts.UseSqlServer(conn)
);

builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingPlanService, TrainingPlanService>();
builder.Services.AddScoped<ITrainingExerciseService, TrainingExerciseService>();
builder.Services.AddScoped<ITrainingPlanTrainingService, TrainingPlanTrainingService>();

builder.Services.AddHealthChecks();

builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("DefaultCache",
        new CacheProfile()
        {
            Duration = 172800
        });
})
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}
);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkoutAppAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors();
builder.Services.AddResponseCaching();

builder.Services.AddAuthentication( options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "WorkoutApp",
            ValidAudience = "WorkoutAppSite",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TESTE")),
            ClockSkew = TimeSpan.FromMinutes(10)
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => {
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    //c.WithOrigins("https://workout-site.vercel.app");
    c.WithOrigins("http://localhost:3000");
});

app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/healthz");

app.MapControllers();

app.Run();