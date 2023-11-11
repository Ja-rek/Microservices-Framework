using MicroFusion.Mediator;

namespace Shop.Orders.Application.Commands.CancelOrder;

public class CancelOrderCommand : ICommand
{
    public CancelOrderCommand(Guid Orderid)
    {
        this.OrderId = Orderid;
    }

    public Guid OrderId { get; }
}