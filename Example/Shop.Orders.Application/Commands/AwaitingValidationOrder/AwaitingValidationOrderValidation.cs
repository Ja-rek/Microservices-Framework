using FluentValidation;

namespace Shop.Orders.Application.Commands.CancelOrder;

public class AwaitingValidationOrderValidation : AbstractValidator<AwaitingValidationOrderCommand>
{
    public AwaitingValidationOrderValidation()
    {
        RuleFor(x => x.OrderId).NotEmpty();
    }
}
