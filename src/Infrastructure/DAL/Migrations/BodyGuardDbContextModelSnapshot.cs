﻿// <auto-generated />
using System;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.DAL.Migrations
{
    [DbContext(typeof(BodyGuardDbContext))]
    partial class BodyGuardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BodyPart")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Core.Entities.ExerciseWorkout", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uuid");

                    b.HasKey("WorkoutId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseWorkouts");
                });

            modelBuilder.Entity("Core.Entities.Goal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("Core.Entities.Measurement", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("CaloriesIntake")
                        .HasMaxLength(250)
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateProvided")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Height")
                        .HasMaxLength(250)
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<double>("Weight")
                        .HasMaxLength(200)
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Core.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("Rate")
                        .HasMaxLength(5)
                        .HasColumnType("integer");

                    b.Property<Guid>("TrainingPlanId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Core.Entities.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uuid");

                    b.Property<int>("Repetitions")
                        .HasMaxLength(1000)
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasMaxLength(500)
                        .HasColumnType("double precision");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId", "ExerciseId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<double>("Duration")
                        .HasMaxLength(20)
                        .HasColumnType("double precision");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanWorkout", b =>
                {
                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TrainingPlanId")
                        .HasColumnType("uuid");

                    b.HasKey("WorkoutId", "TrainingPlanId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("TrainingPlanWorkouts");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("PreferredLanguage")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.UserExercise", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("UserExercises");
                });

            modelBuilder.Entity("Core.Entities.UserTrainingPlan", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TrainingPlanId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BoughtAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("To")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId", "TrainingPlanId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("UserTrainingPlans");
                });

            modelBuilder.Entity("Core.Entities.UserWorkout", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("UserWorkouts");
                });

            modelBuilder.Entity("Core.Entities.UserWorkoutSession", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId", "WorkoutId", "Date");

                    b.HasIndex("WorkoutId");

                    b.ToTable("UserWorkoutSessions");
                });

            modelBuilder.Entity("Core.Entities.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Core.Entities.ExerciseWorkout", b =>
                {
                    b.HasOne("Core.Entities.Exercise", "Exercise")
                        .WithMany("ExerciseWorkouts")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Workout", "Workout")
                        .WithMany("ExerciseWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Core.Entities.Goal", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Measurement", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("Measurements")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Rating", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TrainingPlan", "TrainingPlan")
                        .WithMany("Ratings")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Set", b =>
                {
                    b.HasOne("Core.Entities.ExerciseWorkout", "ExerciseWorkout")
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutId", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseWorkout");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlan", b =>
                {
                    b.HasOne("Core.Entities.User", "Author")
                        .WithMany("CreatedTrainingPlans")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlanWorkout", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlan", "TrainingPlan")
                        .WithMany("TrainingPlanWorkouts")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Workout", "Workout")
                        .WithMany("TrainingPlanWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingPlan");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Core.Entities.UserExercise", b =>
                {
                    b.HasOne("Core.Entities.Exercise", "Exercise")
                        .WithMany("UserExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserExercises")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.UserTrainingPlan", b =>
                {
                    b.HasOne("Core.Entities.TrainingPlan", "TrainingPlan")
                        .WithMany("AllowedUsers")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("AllowedTrainings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.UserWorkout", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Workout", "Workout")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Core.Entities.UserWorkoutSession", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("UserWorkoutSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Workout", "Workout")
                        .WithMany("UserWorkoutSessions")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Core.Entities.Exercise", b =>
                {
                    b.Navigation("ExerciseWorkouts");

                    b.Navigation("UserExercises");
                });

            modelBuilder.Entity("Core.Entities.ExerciseWorkout", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("Core.Entities.TrainingPlan", b =>
                {
                    b.Navigation("AllowedUsers");

                    b.Navigation("Ratings");

                    b.Navigation("TrainingPlanWorkouts");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("AllowedTrainings");

                    b.Navigation("CreatedTrainingPlans");

                    b.Navigation("Goals");

                    b.Navigation("Measurements");

                    b.Navigation("Ratings");

                    b.Navigation("UserExercises");

                    b.Navigation("UserWorkoutSessions");

                    b.Navigation("UserWorkouts");
                });

            modelBuilder.Entity("Core.Entities.Workout", b =>
                {
                    b.Navigation("ExerciseWorkouts");

                    b.Navigation("TrainingPlanWorkouts");

                    b.Navigation("UserWorkoutSessions");

                    b.Navigation("UserWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
