using MicroFusion.DesingByContract;
using Shop.Orders.Domain.Orders;
using System.Runtime.Serialization;

namespace Shop.Orders.Domain.Buyers.Exceptions;

public class OrderException : Exception<OrderException, Order>
{
    public OrderException()
    {
    }

    public OrderException(string? message) : base(message)
    {
    }

    public OrderException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public OrderException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
