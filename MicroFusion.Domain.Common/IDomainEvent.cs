namespace MicroFusion.Domain.AbstractCore;

public interface IDomainEvent
{
    int EventVersion { get; set; }
    DateTime OccurredOn { get; set; }
}
