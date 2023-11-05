namespace MicroservicesFramework.Domain.AbstractCore
{
    public interface IIdentity<T>
    {
        T Value { get; }

        bool Equals(Identity<T>? id);
    }
}