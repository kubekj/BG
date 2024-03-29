using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IUserExerciseRepository
{
    public Task<IEnumerable<UserExercise>> GetAllForUserAsync(Guid userId);
    public Task<IEnumerable<UserExercise>> GetAllAsync(Expression<Func<UserExercise, bool>> expression = default);
    public Task<UserExercise?> GetByIdAsync(Guid userId, Guid exerciseId);

    public Task AddAsync(UserExercise userExercise);

    public Task RemoveAsync(Guid userId, Guid exerciseId);
}