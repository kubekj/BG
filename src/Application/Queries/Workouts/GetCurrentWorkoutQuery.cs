using System;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.Workouts;

public record GetCurrentWorkoutQuery(Guid UserId) : IQuery<WorkoutDto>;