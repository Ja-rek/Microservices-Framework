using MicroFusion.Domain.AbstractCore;
using Shop.Orders.Domain.Buyers.Exceptions;

namespace Shop.Orders.Domain.Orders;

public class Order : IAggregateRoot<OrderId, Guid>
{
    public OrderId Id { get; }
    public OrderStatus Status { get; private set; }
    public Address Address { get; private set; }
    public DateTime Date { get; private set; }
    public BuyerId BuyerId { get; }
    public PaymentMethodId? PaymentMethodId { get; private set; }
    public string Description { get; private set; }
    public bool IsDraft { get; private set; }

    private readonly List<OrderItem> items;
    public IReadOnlyCollection<OrderItem> Items => items;

    private Order(Address address, 
        BuyerId buyerId,
        PaymentMethodId? paymentMethodId = default) : this()
    {
        Address = address;
        BuyerId = buyerId;
        PaymentMethodId = paymentMethodId;
        Status = OrderStatus.Submitted;
        Date = DateTime.UtcNow;
    }

    private Order()
    {
        items = new List<OrderItem>();
        IsDraft = false;
    }

    public Order(OrderId id,
        OrderStatus status,
        Address address,
        DateTime date,
        BuyerId buyerId,
        PaymentMethodId? paymentMethodId,
        string description,
        bool isDraft,
        List<OrderItem> items)
    {
        OrderException.ThrowIfNull(id);
        OrderException.ThrowIfNull(address);
        OrderException.ThrowIfDefault(date);
        OrderException.ThrowIfDefault(BuyerId);

        Id = id;
        Status = status;
        Address = address;
        Date = date;
        BuyerId = buyerId;
        PaymentMethodId = paymentMethodId;
        Description = description;
        IsDraft = isDraft;
        this.items = items;
    }

    public static Order NewDraft()
    {
        var order = new Order();
        order.IsDraft = true;
        return order;
    }

    public static Order StartOrder(Address address,
        BuyerId buyerId,
        PaymentMethodId? paymentMethodId = default)
    {
        return new Order(address, buyerId, paymentMethodId);
    }

    public void AddItem(Guid productId,
        string productName,
        decimal unitPrice,
        decimal discount,
        string pictureUrl,
        int units = 1)
    {
        OrderException.ThrowIfDefault(productId, Id);
        OrderException.ThrowIfNegative(unitPrice);
        OrderException.ThrowIfNegative(units);

        var existingOrderForProduct = items.Where(o => o.ProductId == productId)
            .SingleOrDefault();

        if (existingOrderForProduct != null)
        {
            if (discount > existingOrderForProduct.Discount)
            {
                existingOrderForProduct.ChangeNewDiscount(discount);
            }

            existingOrderForProduct.AddUnits(units);
        }
        else
        {
            var orderItem = new OrderItem(productId, productName, pictureUrl, unitPrice, discount, units);
            items.Add(orderItem);
        }
    }

    public void ChangePayment(PaymentMethodId id)
    {
        OrderException.ThrowIfNull(id?.Value);

        PaymentMethodId = id;
    }

    public void AwaitingValidation()
    {
        OrderException.ThrowIfCannotChange(Status != OrderStatus.Submitted, 
            OrderStatus.AwaitingValidation, 
            Id);

        Status = OrderStatus.AwaitingValidation;
    }

    public void ConfirmStock()
    {
        OrderException.ThrowIfCannotChange(Status != OrderStatus.AwaitingValidation, 
            OrderStatus.StockConfirmed, 
            Id);

        Status = OrderStatus.StockConfirmed;
        Description = "All the items were confirmed with available stock.";
    }

    public void Pay()
    {
        OrderException.ThrowIfCannotChange(Status != OrderStatus.StockConfirmed, 
            OrderStatus.Paid, 
            Id);

        Status = OrderStatus.Paid;
        Description = "The payment was performed at a simulated \"American Bank checking bank account ending on XX35071\"";
    }

    public void Shipment()
    {
        OrderException.ThrowIfCannotChange(Status != OrderStatus.Paid,
            OrderStatus.Shipped,
            Id);

        Status = OrderStatus.Shipped;
        Description = "The order was shipped.";
    }

    public void Cancel()
    {
        OrderException.ThrowIfCannotChange(Status == OrderStatus.Paid || Status == OrderStatus.Shipped, 
            OrderStatus.Cancelled,
            Id);

        Status = OrderStatus.Cancelled;
        Description = $"The order was cancelled.";
    }
}
