using MicroFusion.Domain.AbstractCore;

namespace Shop.Orders.Domain.Orders;

public interface IOrderRepository : IRepository<Order, OrderId, Guid>
{
}
