using FluentValidation;
using Shop.Orders.Application.Queries.GetOrder;

namespace Shop.Orders.Application.Queries.GetOrder;

public class GetOrderQueryValidation : AbstractValidator<GetOrderQuery>
{
    public GetOrderQueryValidation()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
