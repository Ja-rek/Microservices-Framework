using Shop.Orders.Domain.Orders;
using Shop.Orders.Infrastructure.Mongo.Internal;

namespace Shop.Orders.Infrastructure.Mongo;

public class OrderRepository : MongoRepository<OrderData, Order, OrderId>, IOrderRepository
{
    public OrderRepository(MongoCollectionFactory collectionFactory) :
        base(collectionFactory, "vehicles")
    {
    }

    public override OrderData MapToDocument(Order order)
    {
        var mapItems = (OrderItem item) => new OrderItemData(item.ProductId,
            item.ProductName,
            item.PictureUrl,
            item.UnitPrice,
            item.Discount,
            item.Units);

        var address = new AddressData(order.Address.Street,
            order.Address.City,
            order.Address.State,
            order.Address.Country,
            order.Address.ZipCode);

        return new OrderData(order.Id,
            order.Status,
            address,
            order.Date,
            order.BuyerId,
            order.PaymentMethodId?.Value,
            order.Description,
            order.IsDraft,
            order.Items.Select(mapItems).ToList());
    }

    public override Order MapToEntity(OrderData order)
    {
        var mapItems = (OrderItemData item) => new OrderItem(item.ProductId,
            item.ProductName,
            item.PictureUrl,
            item.UnitPrice,
            item.Discount,
            item.Units);

        var address = new Address(order.Address.Street,
            order.Address.City,
            order.Address.State,
            order.Address.Country,
            order.Address.ZipCode);

        return new Order(order.Id,
            order.Status,
            address,
            order.Date,
            order.BuyerId,
            order.PaymentMethodId,
            order.Description,
            order.IsDraft,
            order.Items.Select(mapItems).ToList());
    }
}