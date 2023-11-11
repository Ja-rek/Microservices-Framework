using FluentValidation;

namespace Shop.Orders.Application.Commands.CancelOrder;

public class CancelOrderValidation : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderValidation()
    {
        RuleFor(x => x.OrderId).NotNull();
    }
}
