using MicroFusion.Mediator;
using Shop.Orders.Application.Queries.Resources;

namespace Shop.Orders.Application.Queries.GetOrder;

public class GetOrderQuery : IQuery<OrderResource>
{
    public Guid Id { get; }

    public GetOrderQuery(Guid id)
    {
        Id = id;
    }
}