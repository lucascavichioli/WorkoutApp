﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkoutApp.Data;

#nullable disable

namespace WorkoutApp.Migrations
{
    [DbContext(typeof(WorkoutAppContext))]
    [Migration("20221213023541_Atualizando Campos CreatedAt")]
    partial class AtualizandoCamposCreatedAt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WorkoutApp.Models.Exercises", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("LinkVideo")
                        .HasColumnType("longtext");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("RestSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("WorkoutApp.Models.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Comments")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<short>("DurationMinutes")
                        .HasColumnType("smallint");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("WorkoutApp.Models.TrainingExercises", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Comments")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<Guid>("ExercisesFK")
                        .HasColumnType("char(36)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("TrainingFK")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ExercisesFK");

                    b.HasIndex("TrainingFK");

                    b.ToTable("TrainingExercises");
                });

            modelBuilder.Entity("WorkoutApp.Models.TrainingPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Author")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("Comments")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageLink")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<short>("Length")
                        .HasColumnType("smallint");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("LocationDifficulty")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<short>("PerSession")
                        .HasColumnType("smallint");

                    b.Property<short>("PerWeek")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TrainingPlan");
                });

            modelBuilder.Entity("WorkoutApp.Models.TrainingPlanTraining", b =>
                {
                    b.Property<Guid>("TrainingPlanFK")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TrainingFK")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("TrainingPlanFK", "TrainingFK");

                    b.HasIndex("TrainingFK");

                    b.HasIndex("TrainingPlanFK")
                        .IsUnique();

                    b.ToTable("TrainingPlanTraining");
                });

            modelBuilder.Entity("WorkoutApp.Models.TrainingExercises", b =>
                {
                    b.HasOne("WorkoutApp.Models.Exercises", "Exercises")
                        .WithMany("TrainingExercises")
                        .HasForeignKey("ExercisesFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkoutApp.Models.Training", "Training")
                        .WithMany("TrainingExercises")
                        .HasForeignKey("TrainingFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercises");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("WorkoutApp.Models.TrainingPlanTraining", b =>
                {
                    b.HasOne("WorkoutApp.Models.Training", "Training")
                        .WithMany("TrainingPlanTraining")
                        .HasForeignKey("TrainingFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkoutApp.Models.TrainingPlan", "TrainingPlan")
                        .WithOne("TrainingPlanTraining")
                        .HasForeignKey("WorkoutApp.Models.TrainingPlanTraining", "TrainingPlanFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("TrainingPlan");
                });

            modelBuilder.Entity("WorkoutApp.Models.Exercises", b =>
                {
                    b.Navigation("TrainingExercises");
                });

            modelBuilder.Entity("WorkoutApp.Models.Training", b =>
                {
                    b.Navigation("TrainingExercises");

                    b.Navigation("TrainingPlanTraining");
                });

            modelBuilder.Entity("WorkoutApp.Models.TrainingPlan", b =>
                {
                    b.Navigation("TrainingPlanTraining")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
