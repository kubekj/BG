using System.Runtime.InteropServices.ComTypes;
using Core.SeedWork;
using Core.ValueObjects.Common;
using Core.ValueObjects.Workout;

namespace Core.Entities;

public class Workout : Entity
{
    public Workout(Guid id, WorkoutName name, Category category) : base(id)
    {
        Name = name;
        Category = category;
        TrainingPlanWorkouts = new HashSet<TrainingPlanWorkout>();
        UserWorkouts = new HashSet<UserWorkout>();
        ExerciseWorkouts = new HashSet<ExerciseWorkout>();
    }

    public Workout CreateCopyForUser(string? name = default, string? category = default) => 
        new(Guid.NewGuid(), name ?? Name.Value + " (copy)", category ?? Category);

    public WorkoutName Name { get; }
    public Category Category { get; }
    public IEnumerable<TrainingPlanWorkout> TrainingPlanWorkouts { get; }
    public IEnumerable<UserWorkout> UserWorkouts { get; }
    public IEnumerable<ExerciseWorkout> ExerciseWorkouts { get; }
}