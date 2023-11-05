using FluentValidation;

namespace Shop.Orders.Application.Commands.CancelOrder;

public class CreateOrderValidation : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidation()
    {
    }
}
