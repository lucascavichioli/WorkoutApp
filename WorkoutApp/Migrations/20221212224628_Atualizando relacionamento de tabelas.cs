using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp.Migrations
{
    public partial class Atualizandorelacionamentodetabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_TrainingPlan_TrainingPlanFK",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_TrainingPlanFK",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "TrainingPlanFK",
                table: "Training");

            migrationBuilder.CreateTable(
                name: "TrainingPlanTraining",
                columns: table => new
                {
                    TrainingPlanFK = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TrainingFK = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OrderTraining = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlanTraining", x => new { x.TrainingPlanFK, x.TrainingFK });
                    table.ForeignKey(
                        name: "FK_TrainingPlanTraining_Training_TrainingFK",
                        column: x => x.TrainingFK,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingPlanTraining_TrainingPlan_TrainingPlanFK",
                        column: x => x.TrainingPlanFK,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanTraining_TrainingFK",
                table: "TrainingPlanTraining",
                column: "TrainingFK");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanTraining_TrainingPlanFK",
                table: "TrainingPlanTraining",
                column: "TrainingPlanFK",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingPlanTraining");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingPlanFK",
                table: "Training",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainingPlanFK",
                table: "Training",
                column: "TrainingPlanFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_TrainingPlan_TrainingPlanFK",
                table: "Training",
                column: "TrainingPlanFK",
                principalTable: "TrainingPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
