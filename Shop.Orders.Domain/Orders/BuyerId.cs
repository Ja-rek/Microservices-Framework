using MicroservicesFramework.Domain.AbstractCore;

namespace Shop.Orders.Domain.Orders;

public class BuyerId : Identity<Guid>
{
    public BuyerId() : base(Guid.NewGuid())
    {
    }

    public BuyerId(Guid id) : base(id)
    {
    }

    public static implicit operator Guid(BuyerId identity)
        => identity.Value;

    public static implicit operator BuyerId(Guid id)
        => new BuyerId(id);
}
