using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp.Migrations
{
    public partial class AddrelationshipTrainingandTrainginPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlans",
                table: "TrainingPlans");

            migrationBuilder.RenameTable(
                name: "TrainingPlans",
                newName: "TrainingPlan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlan",
                table: "TrainingPlan",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<short>(type: "smallint", nullable: false),
                    TrainingPlanFK = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_TrainingPlan_TrainingPlanFK",
                        column: x => x.TrainingPlanFK,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainingPlanFK",
                table: "Training",
                column: "TrainingPlanFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPlan",
                table: "TrainingPlan");

            migrationBuilder.RenameTable(
                name: "TrainingPlan",
                newName: "TrainingPlans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPlans",
                table: "TrainingPlans",
                column: "Id");
        }
    }
}
