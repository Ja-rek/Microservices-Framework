namespace MicroFusion.Mediator.Tests.Sut;

public interface ICalculationService
{
    void Calculate(int number, int mumber, CancellationToken cancellation = default);
    void ProcessProduct(ProductDto product);
    void ProcessCommands(IEnumerable<AddCommand> commands);
}