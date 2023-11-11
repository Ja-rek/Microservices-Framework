using MicroFusion.Domain.AbstractCore;
using Shop.Orders.Domain.Buyers.Exceptions;

namespace Shop.Orders.Domain.Orders;

public class OrderItem : IEntity
{
    public OrderItem(Guid productId,
        string productName,
        string pictureUrl,
        decimal unitPrice,
        decimal discount,
        int units)
    {
        OrderItemException.ThrowIfLessThan(1, units);
        OrderItemException.ThrowIfGreaterThan((unitPrice * units), discount);

        ProductId = productId;
        ProductName = productName;
        PictureUrl = pictureUrl;
        UnitPrice = unitPrice;
        Discount = discount;
        Units = units;
    }

    public Guid ProductId { get; set; }
    public string ProductName { get; }
    public string PictureUrl { get; }
    public decimal UnitPrice { get; }
    public decimal Discount { get; private set; }
    public int Units { get; private set; }

    public void ChangeNewDiscount(decimal discount)
    {
        OrderItemException.ThrowIfLessThan(0, discount);

        Discount = discount;
    }

    public void AddUnits(int units)
    {
        OrderItemException.ThrowIfLessThan(0, units);

        Units += units;
    }
}
