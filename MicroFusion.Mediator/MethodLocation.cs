using System.Reflection;

namespace MicroFusion.Mediator;

internal sealed class MethodLocation
{
    public MethodLocation(MethodInfo methodInfo,
        Type serviceType)
    {
        MethodInfo = methodInfo;
        ServiceType = serviceType;
    }

    public MethodInfo MethodInfo { get; }
    public Type ServiceType { get; }
}