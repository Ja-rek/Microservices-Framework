using System.Runtime.Serialization;

namespace MicroservicesFramework.DesingByContract.Tests.Sut;

internal class ProductException : Exception<ProductException, Product>
{
    public ProductException()
    {
    }

    public ProductException(string? message) : base(message)
    {
    }

    public ProductException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public ProductException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
