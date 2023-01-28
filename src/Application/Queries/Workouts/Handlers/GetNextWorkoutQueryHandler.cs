using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Application.Exceptions;
using Core.Repositories;
using Core.Services.UserWorkoutSession;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetNextWorkoutQueryHandler : IQueryHandler<GetWorkoutSessionQuery,WorkoutDto>
{
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepository;
    private readonly IUserWorkoutSessionService _userWorkoutSessionService;

    public GetNextWorkoutQueryHandler(IUserWorkoutSessionRepository userWorkoutSessionRepository,
        IUserWorkoutSessionService userWorkoutSessionService)
    {
        _userWorkoutSessionRepository = userWorkoutSessionRepository;
        _userWorkoutSessionService = userWorkoutSessionService;
    }

    public async Task<WorkoutDto> HandleAsync(GetWorkoutSessionQuery query)
    {
        var userSessions = await _userWorkoutSessionRepository.GetAllAsync(usw => usw.UserId == query.UserId);
        var workout = _userWorkoutSessionService.GetNextUserWorkoutSession(userSessions);

        if (workout is null) throw new NoWorkoutFoundException();

        return workout.Adapt<WorkoutDto>();
    }
}