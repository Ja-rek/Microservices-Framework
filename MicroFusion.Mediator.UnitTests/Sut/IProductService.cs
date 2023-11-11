namespace MicroFusion.Mediator.Tests.Sut;

public interface IProductService
{
    void Delete(DeleteCommand command);
    void DeleteProduct(DeleteCommand command);
    void Calculate(int number, int mumber, CancellationToken cancellation = default);
}