namespace MicroFusion.Domain.AbstractCore;

public class Identity<T> : IEquatable<Identity<T>>, IIdentity<T>
{
    public Identity(T id)
    {
        Value = id;
    }

    public T Value { get; }

    public bool Equals(Identity<T>? id)
    {
        if (ReferenceEquals(this, id))
            return true;

        if (ReferenceEquals(null, id))
            return false;

        return Value.Equals(id.Value);
    }

    public override bool Equals(object? anotherObject)
    {
        return Equals(anotherObject as Identity<T>);
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode() * 907 + Value.GetHashCode();
    }

    public override string ToString()
    {
        return GetType().Name + " [Id=" + Value + "]";
    }

    public static implicit operator T(Identity<T> identity)
        => identity.Value;

    public static implicit operator Identity<T>(T id)
        => new Identity<T>(id);
}
