namespace MicroservicesFramework.Domain.AbstractCore;

public interface IAggregateRoot<T, T2> : IEntity<T, T2>
    where T : Identity<T2>
{
}
