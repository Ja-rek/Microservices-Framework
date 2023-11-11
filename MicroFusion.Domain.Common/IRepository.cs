namespace MicroFusion.Domain.AbstractCore;

public interface IRepository<TEntity, TIdentity, TId> 
    where TIdentity : Identity<TId>
    where TEntity : IEntity<TIdentity, TId>
{
    Task<TEntity> GetAsync(TIdentity id);
    Task DeleteAsync(TEntity vehicle);
    Task SaveAsync(TEntity vehicle);
}