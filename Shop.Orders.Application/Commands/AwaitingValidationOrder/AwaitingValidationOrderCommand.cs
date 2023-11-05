using MicroservicesFramework.Mediator;

namespace Shop.Orders.Application.Commands.CancelOrder;

public class AwaitingValidationOrderCommand : ICommand
{
    public Guid OrderId { get; }

    public AwaitingValidationOrderCommand(Guid orderId)
    {
        OrderId = orderId;
    }
}