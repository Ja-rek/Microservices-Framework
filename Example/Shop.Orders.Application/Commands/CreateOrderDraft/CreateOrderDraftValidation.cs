using FluentValidation;

namespace Shop.Orders.Application.Commands.CancelOrder;

public class CreateOrderDraftValidation : AbstractValidator<CreateOrderDraftCommand>
{
    public CreateOrderDraftValidation()
    {
        RuleFor(x => x.BuyerId).NotNull();
        RuleFor(x => x.Items).NotNull();
    }
}
