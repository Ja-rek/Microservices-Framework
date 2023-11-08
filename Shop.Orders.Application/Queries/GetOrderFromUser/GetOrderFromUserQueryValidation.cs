using FluentValidation;

namespace Shop.Orders.Application.Queries.GetOrderFromUser;

public class GetOrderFromUserQueryValidation : AbstractValidator<GetOrderFromUserQuery>
{
    public GetOrderFromUserQueryValidation()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}
