using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserExerciseRepository : IUserExerciseRepository
{
    private readonly DbSet<UserExercise> _userExercises;

    public UserExerciseRepository(BodyGuardDbContext context) => _userExercises = context.UserExercises;

    public async Task<IEnumerable<UserExercise>> GetAllAsync() => await _userExercises.ToListAsync();
}