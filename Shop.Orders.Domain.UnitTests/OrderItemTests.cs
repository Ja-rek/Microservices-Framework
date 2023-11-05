using Shop.Orders.Domain.Buyers.Exceptions;
using Shop.Orders.Domain.Orders;

namespace Shop.Orders.Domain.UnitTests;

[TestFixture]
public class OrderItemTests
{
    private Fixture fixture;
    private Guid productId;
    private string productName;
    private string pictureUrl;
    private decimal unitPrice;
    private decimal discount;
    private int units;

    [SetUp]
    public void Setup()
    {
        fixture = new Fixture();
        productId = fixture.Create<Guid>();
        productName = fixture.Create<string>();
        pictureUrl = fixture.Create<string>();
        unitPrice = 10.99m;
        discount = 2.00m;
        units = 1;
    }

    [Test]
    public void CreateOrderItem_WithValidData_ShouldSucceed()
    {
        // Act
        var orderItem = CreateOrderItem();

        // Assert
        orderItem.Should().NotBeNull();
        orderItem.ProductId.Should().Be(productId);
        orderItem.ProductName.Should().Be(productName);
        orderItem.PictureUrl.Should().Be(pictureUrl);
        orderItem.UnitPrice.Should().Be(unitPrice);
        orderItem.Discount.Should().Be(discount);
        orderItem.Units.Should().Be(units);
    }

    [Test]
    public void CreateOrderItem_WithInvalidUnits_ShouldThrowOrderItemException()
    {
        // Arrange
        units = 0;

        // Act 
        Action act = () => CreateOrderItem();

        // Assert
        act.Should().Throw<OrderItemException>();
    }

    [Test]
    public void CreateOrderItem_WithInvalidDiscount_ShouldThrowOrderItemException()
    {
        // Arrange
        discount = 15.00m;

        // Act 
        Action act = () => CreateOrderItem();

        // Assert
        act.Should().Throw<OrderItemException>();
    }

    [Test]
    public void ChangeDiscount_WithValidDiscount_ShouldUpdateDiscount()
    {
        // Arrange
        var orderItem = CreateOrderItem();

        // Act
        orderItem.ChangeNewDiscount(3.50m);

        // Assert
        orderItem.Discount.Should().Be(3.50m);
    }

    [Test]
    public void ChangeDiscount_WithInvalidDiscount_ShouldThrowOrderItemException()
    {
        // Arrange
        var orderItem = CreateOrderItem();

        // Act & Assert
        Action act = () => orderItem.ChangeNewDiscount(-1.00m);

        // Assert
        act.Should().Throw<OrderItemException>();
    }

    [Test]
    public void AddUnits_WithValidUnits_ShouldUpdateUnits()
    {
        // Arrange
        var orderItem = CreateOrderItem();

        // Act
        orderItem.AddUnits(3);

        // Assert
        orderItem.Units.Should().Be(4);
    }

    [Test]
    public void AddUnits_WithInvalidUnits_ShouldThrowOrderItemException()
    {
        // Arrange
        var orderItem = CreateOrderItem();

        // Act 
        Action act = () => orderItem.AddUnits(-1);

        // Assert
        act.Should().Throw<OrderItemException>();
    }

    private OrderItem CreateOrderItem()
    {
        return new OrderItem(productId, productName, pictureUrl, unitPrice, discount, units);
    }
}
