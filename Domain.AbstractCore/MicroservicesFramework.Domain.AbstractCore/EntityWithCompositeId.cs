namespace MicroservicesFramework.Domain.AbstractCore;

public abstract class EntityWithCompositeId
{
    protected abstract IEnumerable<object> GetIdentityComponents();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (ReferenceEquals(null, obj))
            return false;

        if (GetType() != obj.GetType())
            return false;

        var other = obj as EntityWithCompositeId;
        var identityComponents = other?.GetIdentityComponents() ?? Enumerable.Empty<object>();

        return GetIdentityComponents().SequenceEqual(identityComponents);
    }

    public override int GetHashCode()
    {
        return HashCodeHelper.CombineHashCodes(GetIdentityComponents());
    }
}