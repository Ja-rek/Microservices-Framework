namespace MicroFusion.Mediator.Tests;

//public class MediatorTest
//{
//    private IMediator mediator;
//    private Mock<IService> serviceMock;
//    private ProductDto dto;
//
//    [OneTimeSetUp]
//    public void OneTimeSetUp()
//    {
//        var services = new ServiceCollection();
//        services
//            .AddTransient(_ => serviceMock.Object)
//            .AddMediator(typeof(IService));
//
//#pragma warning disable CS8601 // Possible null reference assignment.
//        mediator = services
//            .BuildServiceProvider()
//            .CreateScope()
//            .ServiceProvider
//            .GetService(typeof(IMediator)) as IMediator;
//#pragma warning restore CS8601
//    }
//
//    [SetUp]
//    public void Setup()
//    {
//        serviceMock = new Mock<IService>();
//        dto = new ProductDto();
//    }
//
//    [Test]
//    public async Task Send_CanInvokeQueryMethod()
//    {
//        var query = new GetQuery();
//        serviceMock.Setup(x => x.Get(query))
//            .Returns(dto);
//
//        var expectedResult = await mediator.Send(query);
//
//        serviceMock.Verify(x => x.Get(query));
//        expectedResult.Should().Be(dto);
//    }
//
//    [Test]
//    public async Task Send_CanInvokeĄsyncQueryMethod()
//    {
//        var query = new GetAsyncQuery();
//        serviceMock.Setup(x => x.GetAsync(query))
//            .ReturnsAsync(dto);
//
//        var expectedResult = await mediator.Send(query);
//
//        serviceMock.Verify(x => x.GetAsync(query));
//        expectedResult.Should().Be(dto);
//    }
//
//    [Test]
//    public async Task Send_CanInvokeCommandMethod()
//    {
//        var command = new AddCommand();
//
//        await mediator.Send(command);
//
//        serviceMock.Verify(x => x.Add(command));
//    }
//
//    [Test]
//    public async Task Send_CanInvokeAsyncCommandMethod()
//    {
//        var command = new AddAsyncCommand();
//
//        await mediator.Send(command);
//
//        serviceMock.Verify(x => x.AddAsync(command));
//    }
//
//    [Test]
//    public async Task Send_CanInvokeCommandMethodTahtReturnsValue()
//    {
//        var command = new AddAndReturnCommand();
//        serviceMock.Setup(x => x.AddAndReturn(command))
//            .Returns(dto);
//
//        var expectedResult = await mediator.Send(command);
//
//        serviceMock.Verify(x => x.AddAndReturn(command));
//        expectedResult.Should().Be(dto);
//    }
//
//    [Test]
//    public async Task Send_CanInvokeAsyncCommandMethodTahtReturnsValue()
//    {
//        var command = new AddAndReturnAsyncCommand();
//        serviceMock.Setup(x => x.AddAndReturnAsync(command))
//            .ReturnsAsync(dto);
//
//        var expectedResult = await mediator.Send(command);
//
//        serviceMock.Verify(x => x.AddAndReturnAsync(command));
//        expectedResult.Should().Be(dto);
//    }
//}