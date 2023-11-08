using Shop.Orders.Application.Queries.GetOrder;
using Shop.Orders.Application.Queries.GetOrderFromUser;
using Shop.Orders.Application.Queries.Resources;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Queries;

//Interface for AutoFac Interceptors
public interface IOrderQueryService
{
    Task<OrderResource> GetOrderAsync(GetOrderQuery cmd);
    Task<IEnumerable<OrderSummaryResource>> GetOrdersFromUserAsync(GetOrderFromUserQuery userId);
}
