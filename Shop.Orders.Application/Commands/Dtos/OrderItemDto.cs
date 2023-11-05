namespace Shop.Orders.Application.Commands.CancelOrder;

public record OrderItemDto
{
    public OrderItemDto(Guid productId,
        string? productName,
        decimal unitPrice,
        decimal discount,
        int units,
        string? pictureUrl)
    {
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Discount = discount;
        Units = units;
        PictureUrl = pictureUrl;
    }

    public Guid ProductId { get; init; }
    public string? ProductName { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal Discount { get; init; }
    public int Units { get; init; }
    public string? PictureUrl { get; init; }
}