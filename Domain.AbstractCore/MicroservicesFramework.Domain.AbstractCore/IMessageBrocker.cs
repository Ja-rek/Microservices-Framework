namespace MicroservicesFramework.Domain.AbstractCore;

public interface IMessageBroker
{
    Task PublishAsync(params IEvent[] events);
    Task PublishAsync(IEnumerable<IEvent> events);
}
