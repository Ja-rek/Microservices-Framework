namespace MicroFusion.Domain.AbstractCore;

public interface IEntity<TIdentity, TId>
    where TIdentity : Identity<TId>
{
    TIdentity Id { get; }
}

public interface IEntity
{
}
