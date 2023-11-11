namespace MicroFusion.Domain.AbstractCore;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (ReferenceEquals(null, obj))
            return false;

        if (GetType() != obj.GetType())
            return false;

        var vo = obj as ValueObject;
        var equalityComponents = vo?.GetEqualityComponents() ?? Enumerable.Empty<object>();

        return GetEqualityComponents().SequenceEqual(equalityComponents);
    }

    public override int GetHashCode()
    {
        return HashCodeHelper.CombineHashCodes(GetEqualityComponents());
    }
}
