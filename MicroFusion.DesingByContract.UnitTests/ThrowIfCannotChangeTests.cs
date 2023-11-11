namespace MicroFusion.DesingByContract.Tests;

[TestFixture]
public class ThrowIfCannotChangeTests
{
    private const string CustomMessage = "Custom error message";

    [Test]
    public void ThrowIfCannotChangeStatus_UnsuccessfulStatusChange_ExceptionThrown()
    {
        // Arrange
        var type = ProductType.Food;

        // Act
        Action action = () => ProductException.ThrowIfCannotChange(type == ProductType.Food, ProductType.Chemicals);

        // Assert
        action.Should()
            .Throw<Exception>()
            .WithMessage("When 'type == ProductType.Food' then you cannot change state to 'ProductType.Chemicals'.");
    }

    [Test]
    public void ThrowIfCannotChangeStatus_UnsuccessfulStatusChangeWithId_ExceptionThrown()
    {
        // Arrange
        var type = ProductType.Food;
        var id = 42;

        // Act
        Action action = () => ProductException.ThrowIfCannotChange(type == ProductType.Food, ProductType.Chemicals, id);

        // Assert
        action.Should()
            .Throw<Exception>()
            .WithMessage("When 'type == ProductType.Food' then you cannot change state to 'ProductType.Chemicals' in 'Product with id:42'.");
    }

    [Test]
    public void ThrowIfCannotChangeStatus_UnsuccessfulStatusChangeWithCustomMessage_ExceptionThrown()
    {
        // Arrange
        var type = ProductType.Food;

        // Act
        Action action = () => ProductException.ThrowIfCannotChange(type == ProductType.Food, ProductType.Chemicals, 42, CustomMessage);

        // Assert
        action.Should()
            .Throw<Exception>()
            .WithMessage(CustomMessage);
    }
    
    [Test]
    public void ThrowIfCannotChangeStatus_SuccessfulStatusChange_NoExceptionThrown()
    {
        // Act
        Action action = () => ProductException.ThrowIfCannotChange(false, ProductType.Chemicals, 42, CustomMessage);

        // Assert
        action.Should()
            .NotThrow<Exception>();
    }

    [Test]
    public void ThrowIfCannotChangeStatus_StatusChangeWithNullNewStatusName_ExceptionThrown()
    {
        // Act
        Action action = () => ProductException.ThrowIfCannotChange(true, ProductType.Chemicals, 42, CustomMessage, "whenName", null);

        // Assert
        action.Should()
            .Throw<ArgumentException>();
    }
}

