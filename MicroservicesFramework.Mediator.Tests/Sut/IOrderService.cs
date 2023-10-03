namespace MicroservicesFramework.Mediator.Tests.Sut;

public interface IOrderService
{
    void AddOrder(AddOrderCommand command);
}