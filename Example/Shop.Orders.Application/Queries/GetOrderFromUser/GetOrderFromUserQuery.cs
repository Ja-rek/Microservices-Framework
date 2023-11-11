using MicroFusion.Mediator;
using Shop.Orders.Application.Queries.Resources;

namespace Shop.Orders.Application.Queries.GetOrderFromUser;

public class GetOrderFromUserQuery : IQuery<OrderResource>
{
    public Guid UserId { get; }

    public GetOrderFromUserQuery(Guid userId)
    {
        UserId = userId;
    }
}