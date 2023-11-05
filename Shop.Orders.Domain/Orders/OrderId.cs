using MicroservicesFramework.Domain.AbstractCore;

namespace Shop.Orders.Domain.Orders;

public class OrderId : Identity<Guid>
{
    public OrderId() : base(Guid.NewGuid())
    {
    }

    public OrderId(Guid id) : base(id)
    {
    }

    public static implicit operator Guid(OrderId identity)
        => identity.Value;

    public static implicit operator OrderId(Guid id)
        => new OrderId(id);
}


