namespace MicroFusion.Mediator.Tests;

public class DependencyInjectionExtensionTests
{
    private ServiceCollection services;

//    [OneTimeSetUp]
//    public void OneTimeSetUp()
//    {
//        services = new ServiceCollection();
//        services.AddMediator();
//    }
//
//    [Test]
//    public void AddMediatorService_WhenMessageHaveMoreThanOneHandler_ThrowException()
//    {
//        var serviceStub = new Mock<IProductService>();
//        services.AddScoped(_ => serviceStub.Object);
//
//        var throwIfCommandHaveMoreThanOneHandler = () => services.AddMediator(typeof(IProductService));
//
//        throwIfCommandHaveMoreThanOneHandler.Should()
//            .Throw<InvalidOperationException>()
//            .WithMessage($"Message 'DeleteCommand' must have one handler method.");
//    }
//
//    [Test]
//    public void AddMediatorService_WhenMessageHaveOneHandler_NotThrowException()
//    {
//        var serviceStub = new Mock<IOrderService>();
//        services.AddScoped(_ => serviceStub.Object);
//
//        var throwIfCommandHaveMoreThanOneHandler = () => services
//            .AddMediator(typeof(IOrderService));
//
//        throwIfCommandHaveMoreThanOneHandler.Should()
//            .NotThrow<InvalidOperationException>();
//    }
//
//    [Test]
//    public void AddMediatorService_WhenMessageHaveNoHandlerInService_DontAddHandlers()
//    {
//        var serviceStub = new Mock<ICalculationService>();
//        services.AddScoped(_ => serviceStub.Object);
//        services.AddMediator(typeof(ICalculationService));
//
//        var isAnyHandlerFromCalculationServiceAddedToMediator = MethodLocator.Methods.Any(x => x.Value.ServiceType == typeof(ICalculationService));
//
//        isAnyHandlerFromCalculationServiceAddedToMediator.Should().BeTrue();
//    }
}