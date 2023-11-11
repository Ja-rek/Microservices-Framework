namespace MicroFusion.Mediator;

internal sealed class MethodLocator
{
    private static readonly Lazy<IDictionary<Type, MethodLocation>> _lazy =
        new Lazy<IDictionary<Type, MethodLocation>>(() => new Dictionary<Type, MethodLocation>());

    public static IDictionary<Type, MethodLocation> Methods => _lazy.Value;
}