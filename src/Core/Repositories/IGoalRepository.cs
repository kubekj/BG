using Core.Entities;

namespace Core.Repositories;

public interface IGoalRepository
{
    public Task<int> GetByMonth(Guid userId);
    public Task AddAsync(Goal goal);
    public Task EditAsync(Goal goal);
}