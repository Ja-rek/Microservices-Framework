using MicroFusion.Mediator;

namespace Shop.Orders.Application.Commands.CancelOrder;

public partial class CreateOrderDraftCommand : ICommand
{
    public CreateOrderDraftCommand(string buyerId, IEnumerable<OrderItemDto> items)
    {
        BuyerId = buyerId;
        Items = items;
    }

    public string BuyerId { get; }
    public IEnumerable<OrderItemDto> Items { get; }
}