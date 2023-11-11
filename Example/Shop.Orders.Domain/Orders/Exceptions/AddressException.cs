using MicroFusion.DesingByContract;
using Shop.Orders.Domain.Orders;
using System.Runtime.Serialization;

namespace Shop.Orders.Domain.Buyers.Exceptions;

public class AddressException : Exception<AddressException, Address>
{
    public AddressException()
    {
    }

    public AddressException(string? message) : base(message)
    {
    }

    public AddressException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public AddressException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
