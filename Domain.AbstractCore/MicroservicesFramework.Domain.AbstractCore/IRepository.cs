namespace MicroservicesFramework.Domain.AbstractCore;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> GetAsync(Guid id);
    Task DeleteAsync(TEntity vehicle);
    Task SaveAsync(TEntity vehicle);
}