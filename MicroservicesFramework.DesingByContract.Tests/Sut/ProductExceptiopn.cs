using System.Runtime.Serialization;

namespace MicroservicesFramework.DesingByContract.Tests.Sut;

internal class ProductExceptiopn : Exception<ProductExceptiopn, Product>
{
    public ProductExceptiopn()
    {
    }

    public ProductExceptiopn(string? message) : base(message)
    {
    }

    public ProductExceptiopn(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public ProductExceptiopn(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
