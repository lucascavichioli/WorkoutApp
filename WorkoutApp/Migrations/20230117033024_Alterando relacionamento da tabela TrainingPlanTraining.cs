using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp.Migrations
{
    public partial class AlterandorelacionamentodatabelaTrainingPlanTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainingPlanTraining_TrainingPlanFK",
                table: "TrainingPlanTraining");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlanTraining_TrainingPlanFK",
                table: "TrainingPlanTraining",
                column: "TrainingPlanFK",
                unique: true);
        }
    }
}
