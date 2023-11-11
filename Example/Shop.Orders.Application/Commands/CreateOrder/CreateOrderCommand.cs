using MicroFusion.Mediator;

namespace Shop.Orders.Application.Commands.CancelOrder;

public class CreateOrderCommand : ICommand
{
    public CreateOrderCommand(List<int> basketItems,
        Guid userId,
        string userName,
        string city,
        string street,
        string state,
        string country,
        string zipcode,
        Guid paymentMethodId,
        IEnumerable<OrderItemDto> items)
    {
        BasketItems = basketItems;
        UserId = userId;
        UserName = userName;
        City = city;
        Street = street;
        State = state;
        Country = country;
        Zipcode = zipcode;
        PaymentMethodId = paymentMethodId;
        Items = items;
    }

    public List<int> BasketItems { get; }
    public Guid UserId { get; }
    public string UserName { get; }
    public string City { get; }
    public string Street { get; }
    public string State { get; }
    public string Country { get; }
    public string Zipcode { get; }
    public Guid  PaymentMethodId { get; }
    public IEnumerable<OrderItemDto> Items { get; }
}