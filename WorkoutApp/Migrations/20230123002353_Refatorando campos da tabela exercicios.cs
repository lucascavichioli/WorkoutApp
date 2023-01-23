using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp.Migrations
{
    public partial class Refatorandocamposdatabelaexercicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "RestSeconds",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Reps",
                table: "TrainingExercises",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "RestSeconds",
                table: "TrainingExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "TrainingExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reps",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "RestSeconds",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "TrainingExercises");

            migrationBuilder.AddColumn<int>(
                name: "DurationMinutes",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reps",
                table: "Exercises",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "RestSeconds",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
