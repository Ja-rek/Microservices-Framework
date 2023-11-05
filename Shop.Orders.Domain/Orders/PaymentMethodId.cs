using MicroservicesFramework.Domain.AbstractCore;

namespace Shop.Orders.Domain.Orders;

public class PaymentMethodId : Identity<Guid>
{
    public PaymentMethodId() : base(Guid.NewGuid())
    {
    }

    public PaymentMethodId(Guid id) : base(id)
    {
    }

    public static implicit operator Guid(PaymentMethodId identity)
        => identity.Value;

    public static implicit operator PaymentMethodId(Guid id)
        => new PaymentMethodId(id);
}
