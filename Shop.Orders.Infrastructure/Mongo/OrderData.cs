using Shop.Orders.Domain.Orders;
using Shop.Orders.Infrastructure.Mongo.Internal;

namespace Shop.Orders.Infrastructure.Mongo;

public class OrderData : IDocument
{
    public OrderData(Guid id,
        OrderStatus status,
        AddressData address,
        DateTime date,
        Guid buyerId,
        Guid? paymentMethodId,
        string description,
        bool isDraft,
        IEnumerable<OrderItemData> items)
    {
        Id = id;
        Status = status;
        Address = address;
        Date = date;
        BuyerId = buyerId;
        PaymentMethodId = paymentMethodId;
        Description = description;
        IsDraft = isDraft;
        this.Items = items;
    }

    public Guid Id { get; }
    public OrderStatus Status { get; }
    public AddressData Address { get; }
    public DateTime Date { get; }
    public Guid BuyerId { get; }
    public Guid? PaymentMethodId { get; }
    public string Description { get; }
    public bool IsDraft { get; }
    public IEnumerable<OrderItemData> Items { get; }
}

