using Shop.Orders.Application.Queries.Resources;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Queries;

public interface IOrderQueryService
{
    Task<OrderResource> GetOrderAsync(Guid id);

    Task<IEnumerable<OrderSummaryResource>> GetOrdersFromUserAsync(Guid userId);
}
