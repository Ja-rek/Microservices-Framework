using Shop.Orders.Application.Commands.CancelOrder;

namespace Shop.Orders.Application.Commands
{
    public interface IOrderCommandService
    {
        Task AwaitingValidationOrder(AwaitingValidationOrderCommand cmd);
        Task CancelOrder(CancelOrderCommand cmd);
        Task CreateOrder(CreateOrderCommand cmd);
        Task CreateOrder(CreateOrderDraftCommand cmd);
    }
}