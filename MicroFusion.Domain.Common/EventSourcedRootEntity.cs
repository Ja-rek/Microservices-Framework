namespace MicroFusion.Domain.AbstractCore;

public abstract class EventSourcedRootEntity : EntityWithCompositeId
{
    public EventSourcedRootEntity()
    {
        mutatingEvents = new List<IDomainEvent>();
    }

    public EventSourcedRootEntity(IEnumerable<IDomainEvent> eventStream, int streamVersion)
        : this()
    {
        foreach (var e in eventStream)
            When(e);
        unmutatedVersion = streamVersion;
    }

    readonly List<IDomainEvent> mutatingEvents;
    readonly int unmutatedVersion;

    protected int MutatedVersion
    {
        get { return unmutatedVersion + 1; }
    }

    protected int UnmutatedVersion
    {
        get { return unmutatedVersion; }
    }

    public IList<IDomainEvent> GetMutatingEvents()
    {
        return mutatingEvents.ToArray();
    }

    void When(IDomainEvent e)
    {
        (this as dynamic).Apply(e);
    }

    protected void Apply(IDomainEvent e)
    {
        mutatingEvents.Add(e);
        When(e);
    }
}
