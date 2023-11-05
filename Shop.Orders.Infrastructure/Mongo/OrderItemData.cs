
using Shop.Orders.Domain.Orders;

namespace Shop.Orders.Infrastructure.Mongo;

public class OrderItemData
{
    public OrderItemData(OrderItem order)
    {
        ProductId = order.ProductId;
        ProductName = order.ProductName;
        PictureUrl = order.PictureUrl;
        UnitPrice = order.UnitPrice;
        Discount = order.Discount;
        Units = order.Units;
    }

    public OrderItemData(Guid productId,
        string productName,
        string pictureUrl,
        decimal unitPrice,
        decimal discount,
        int units)
    {
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
    public decimal Discount { get; }
    public int Units { get; }
}

