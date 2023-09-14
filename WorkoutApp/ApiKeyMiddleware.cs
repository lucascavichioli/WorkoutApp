using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Obtenha a chave de API da solicitação
        if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKey))
        {
            context.Response.StatusCode = 401; // Não autorizado
            await context.Response.WriteAsync("Acesso não autorizado.");
            return;
        }
        // Verifique se a chave de API é válida
        var validApiKey = _configuration.GetValue<string>("ApiKey");
        if (!string.Equals(apiKey, validApiKey, StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = 401; // Não autorizado
            await context.Response.WriteAsync("Acesso não autorizado.");
            return;
        }

        // A chave de API é válida, continue com a solicitação
        await _next(context);
    }
}