using MicroservicesFramework.DesingByContract;
using Shop.Orders.Domain.Orders;
using System.Runtime.Serialization;

namespace Shop.Orders.Domain.Buyers.Exceptions;

public class OrderItemException : Exception<OrderItemException, OrderItem>
{
    public OrderItemException()
    {
    }

    public OrderItemException(string? message) : base(message)
    {
    }

    public OrderItemException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public OrderItemException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
