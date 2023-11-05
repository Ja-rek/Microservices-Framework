using Microsoft.eShopOnContainers.Services.Ordering.API.Application.Queries;
using MongoDB.Driver;
using Shop.Orders.Application.Queries.Resources;
using Shop.Orders.Infrastructure.Mongo.Internal;

namespace Shop.Orders.Infrastructure.Mongo
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly IMongoCollection<OrderData> orderCollection;

        public OrderQueryService(IMongoCollectionFactory collectionFactory)
        {
            orderCollection = collectionFactory.Collection<OrderData>("orders");
        }

        public async Task<OrderResource> GetOrderAsync(Guid id)
        {
            var filter = Builders<OrderData>.Filter.Eq(order => order.Id, id);
            var order = await orderCollection.Find(filter).FirstOrDefaultAsync();

            return MapToOrderResource(order);
        }

        public async Task<IEnumerable<OrderSummaryResource>> GetOrdersFromUserAsync(Guid userId)
        {
            var filter = Builders<OrderData>.Filter.Eq(order => order.BuyerId, userId);
            var orders = await orderCollection.Find(filter).ToListAsync();

            return orders.Select(MapToOrderSummaryResource);
        }

        private static OrderResource MapToOrderResource(OrderData orderData)
        {
            var mapItems = (OrderItemData item) => new OrderItemResource(productname: item.ProductName,
                units: item.Units,
                unitprice: (double)item.UnitPrice,
                pictureurl: item.PictureUrl);

            return new OrderResource(
                id: orderData.Id,
                date: orderData.Date,
                status: orderData.Status.ToString(),
                description: orderData.Description,
                street: orderData.Address.Street,
                city: orderData.Address.City,
                zipcode: orderData.Address.ZipCode,
                country: orderData.Address.Country,
                orderItems: orderData.Items.Select(mapItems).ToList(),
                total: CalculateTotal(orderData.Items)
            );
        }

        private OrderSummaryResource MapToOrderSummaryResource(OrderData order)
        {
            return new OrderSummaryResource(order.Id,
                order.Date,
                order.Status.ToString(),
                CalculateTotal(order.Items));
        }

        private static decimal CalculateTotal(IEnumerable<OrderItemData> items)
        {
            return items.Sum(item => item.UnitPrice * item.Units);
        }
    }
}
