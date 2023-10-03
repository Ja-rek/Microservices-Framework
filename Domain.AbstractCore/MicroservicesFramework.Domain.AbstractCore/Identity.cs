namespace MicroservicesFramework.Domain.AbstractCore;

public class Identity : IEquatable<Identity>
{
    public Identity()
    {
        Value = Guid.NewGuid();
    }

    public Identity(Guid id)
    {
        Value = id;
    }

    public Guid Value { get; }

    public bool Equals(Identity? id)
    {
        if (ReferenceEquals(this, id))
            return true;

        if (ReferenceEquals(null, id))
            return false;

        return Value.Equals(id.Value);
    }

    public override bool Equals(object? anotherObject)
    {
        return Equals(anotherObject as Identity);
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode() * 907 + Value.GetHashCode();
    }

    public override string ToString()
    {
        return GetType().Name + " [Id=" + Value + "]";
    }

    public static implicit operator Guid(Identity identity)
        => identity.Value;

    public static implicit operator Identity(Guid id)
        => new Identity(id);
}
