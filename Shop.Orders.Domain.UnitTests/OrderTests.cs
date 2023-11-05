using Shop.Orders.Domain.Buyers.Exceptions;
using Shop.Orders.Domain.Orders;

namespace Shop.Orders.Domain.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private Fixture fixture;
        private Guid productId;
        private string productName;
        private string pictureUrl;
        private decimal unitPrice;
        private decimal discount;
        private Address address;
        private BuyerId buyerId;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
            productId = fixture.Create<Guid>();
            productName = fixture.Create<string>();
            pictureUrl = fixture.Create<string>();
            unitPrice = 10.99m;
            discount = 2.00m;
            address = fixture.Create<Address>();
            buyerId = fixture.Create<BuyerId>();
        }

        [Test]
        public void StartOrder_WithValidData_ShouldCreateNewDraftOrder()
        {
            // Act
            var order = Order.StartOrder(address, buyerId);

            // Assert
            order.Should().NotBeNull();
            order.IsDraft.Should().BeFalse();
            order.Status.Should().Be(OrderStatus.Submitted);
            order.Address.Should().BeEquivalentTo(address);
            order.BuyerId.Should().Be(buyerId);
        }

        [Test]
        public void AddItem_WithNegativeUnitPrice_ShouldThrowOrderException()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);

            // Act 
            Action act = () => order.AddItem(productId, productName, -unitPrice, discount, pictureUrl);

            // Assert
            act.Should().Throw<OrderException>();
        }

        [Test]
        public void AddItem_WithValidData_ShouldAddItemToOrder()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);

            // Act
            order.AddItem(productId, productName, unitPrice, discount, pictureUrl);

            // Assert
            order.Items.Should().NotBeNullOrEmpty().And.HaveCount(1);
            var item = order.Items.Should().ContainSingle().Subject;
            item.ProductId.Should().Be(productId);
            item.ProductName.Should().Be(productName);
            item.UnitPrice.Should().Be(unitPrice);
            item.Discount.Should().Be(discount);
            item.PictureUrl.Should().Be(pictureUrl);
        }

        [Test]
        public void AddItem_WithExistingProduct_ShouldUpdateExistingItem()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AddItem(productId, productName, unitPrice, discount, pictureUrl);

            // Act
            var updatedDiscount = 3.00m;
            order.AddItem(productId, productName, unitPrice, updatedDiscount, pictureUrl);

            // Assert
            order.Items.Should().NotBeNullOrEmpty().And.HaveCount(1);
            var item = order.Items.Should().ContainSingle().Subject;
            item.ProductId.Should().Be(productId);
            item.ProductName.Should().Be(productName);
            item.UnitPrice.Should().Be(unitPrice);
            item.Discount.Should().Be(updatedDiscount); // Verify that the discount is updated
            item.PictureUrl.Should().Be(pictureUrl);
        }

        [Test]
        public void AddItem_WithExistingProduct_ShouldIncrementUnits()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AddItem(productId, productName, unitPrice, discount, pictureUrl);

            // Act
            var additionalUnits = 3;
            order.AddItem(productId, productName, unitPrice, discount, pictureUrl, additionalUnits);

            // Assert
            order.Items.Should().NotBeNullOrEmpty().And.HaveCount(1);
            var item = order.Items.Should().ContainSingle().Subject;
            item.ProductId.Should().Be(productId);
            item.ProductName.Should().Be(productName);
            item.UnitPrice.Should().Be(unitPrice);
            item.Discount.Should().Be(discount);
            item.PictureUrl.Should().Be(pictureUrl);
            item.Units.Should().Be(1 + additionalUnits); // Verify that units are incremented
        }


        [Test]
        public void ChangePayment_WithValidPaymentMethodId_ShouldChangePaymentMethod()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            var paymentMethodId = fixture.Create<PaymentMethodId>();

            // Act
            order.ChangePayment(paymentMethodId);

            // Assert
            order.PaymentMethodId.Should().Be(paymentMethodId);
        }

        [Test]
        public void ChangePayment_WithNullPaymentMethodId_ShouldThrowOrderException()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);

            // Act
            Action act = () => order.ChangePayment(null);

            // Assert
            act.Should().Throw<OrderException>();
        }

        [Test]
        public void AwaitingValidation_WhenNotSubmitted_ShouldThrowOrderException()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AwaitingValidation();
            order.ConfirmStock();

            // Act 
            Action act = () => order.AwaitingValidation();

            // Assert
            act.Should().Throw<OrderException>();
        }

        [Test]
        public void AwaitingValidation_WhenStartOrder_ShouldUpdateStatusToSubmitted()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);

            // Assert
            order.Status.Should().Be(OrderStatus.Submitted);
        }

        [Test]
        public void ConfirmStock_WhenNotAwaitingValidation_ShouldThrowOrderException()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);

            // Act 
            Action act = () => order.ConfirmStock();

            // Assert
            act.Should().Throw<OrderException>();
        }

        [Test]
        public void ConfirmStock_WhenStatusIsAwaitingValidation_ShouldUpdateStatusToStockConfirmed()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AwaitingValidation();

            // Act
            order.ConfirmStock();

            // Assert
            order.Status.Should().Be(OrderStatus.StockConfirmed);
        }

        [Test]
        public void Pay_WhenNotStockConfirmed_ShouldThrowOrderException()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);

            // Act 
            Action act = () => order.Pay();

            // Assert
            act.Should().Throw<OrderException>();
        }

        [Test]
        public void Pay_WhenStatusIsStockConfirmed_ShouldUpdateStatusToPaid()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AwaitingValidation();
            order.ConfirmStock();

            // Act
            order.Pay();

            // Assert
            order.Status.Should().Be(OrderStatus.Paid);
        }

        [Test]
        public void Shipment_WhenStatusIsPaid_ShouldUpdateStatusToShipped()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AwaitingValidation();
            order.ConfirmStock();
            order.Pay();

            // Act
            order.Shipment();

            // Assert
            order.Status.Should().Be(OrderStatus.Shipped);
        }

        [Test]
        public void Shipment_WhenStatusIsNotPaid_ShouldThrowOrderException()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);

            // Act 
            Action act = () => order.Shipment();

            // Assert
            act.Should().Throw<OrderException>();
        }

        [Test]
        public void Cancel_WhenStatusIsPaid_ShouldUpdateStatusToCancelled()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AwaitingValidation();
            order.ConfirmStock();
            order.Pay();

            // Act
              Action act = () => order.Cancel();

            // Assert
            act.Should().Throw<OrderException>();
        }

        [Test]
        public void Cancel_WhenStatusIsShipped_ShouldThrowOrderException()
        {
            // Arrange
            var order = Order.StartOrder(address, buyerId);
            order.AwaitingValidation();
            order.ConfirmStock();
            order.Pay();
            order.Shipment();

            // Act 
            Action act = () => order.Cancel();

            // Assert
            act.Should().Throw<OrderException>();
        }
    }
}

