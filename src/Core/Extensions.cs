using Core.Services.Exercise;
using Core.Services.ExerciseWorkout;
using Core.Services.TrainingPlan;
using Core.Services.UserExercise;
using Core.Services.UserWorkout;
using Core.Services.UserWorkoutSession;
using Core.Services.Workout;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Extensions
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IUserExerciseService, UserExerciseService>();
        services.AddSingleton<IExerciseService, ExerciseService>();
        services.AddSingleton<IWorkoutService, WorkoutService>();
        services.AddSingleton<IUserWorkoutService, UserWorkoutService>();
        services.AddSingleton<ITrainingPlanService, TrainingPlanService>();
        services.AddSingleton<IUserWorkoutSessionService, UserWorkoutSessionService>();
        services.AddScoped<IExerciseWorkoutService, ExerciseWorkoutService>();
    }
}