using Shop.Orders.Application.Commands.CancelOrder;
using Shop.Orders.Domain.Buyers.Exceptions;
using Shop.Orders.Domain.Orders;

namespace Shop.Orders.Application.Commands;

public class OrderCommandService : IOrderCommandService
{
    private readonly IOrderRepository orderRepository;

    public OrderCommandService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task AwaitingValidationOrder(AwaitingValidationOrderCommand cmd)
    {
        OrderException.ThrowIfNull(cmd);

        var order = await orderRepository.GetAsync(cmd.OrderId);
        order.AwaitingValidation();

        await orderRepository.SaveAsync(order);
    }

    public async Task CancelOrder(CancelOrderCommand cmd)
    {
        OrderException.ThrowIfNull(cmd);

        var order = await orderRepository.GetAsync(cmd.OrderId);
        order.Cancel();

        await orderRepository.SaveAsync(order);
    }

    public async Task CreateOrder(CreateOrderCommand cmd)
    {
        OrderException.ThrowIfNull(cmd);

        var adress = new Address(cmd.Street,
            cmd.City,
            cmd.State,
            cmd.Country,
            cmd.Zipcode);

        var order = Order.StartOrder(adress,
            cmd.UserId,
            cmd.PaymentMethodId);

        foreach (var item in cmd.Items)
        {
            order.AddItem(item.ProductId,
                item.ProductName,
                item.UnitPrice,
                item.Discount,
                item.PictureUrl,
                item.Units);
        }

        await orderRepository.SaveAsync(order);
    }

    public async Task CreateOrder(CreateOrderDraftCommand cmd)
    {
        var order = Order.NewDraft();

        foreach (var item in cmd.Items)
        {
            order.AddItem(item.ProductId,
                item.ProductName,
                item.UnitPrice,
                item.Discount,
                item.PictureUrl,
                item.Units);
        }

        await orderRepository.SaveAsync(order);
    }
}
