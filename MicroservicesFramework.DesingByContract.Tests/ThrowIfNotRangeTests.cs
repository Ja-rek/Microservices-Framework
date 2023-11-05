namespace MicroservicesFramework.DesingByContract.Tests;

public class ThrowIfNotRangeTests
{
    private const int MinValue = 10;
    private const int MaxValue = 20;
    private const int ValueInsideRange = 15;
    private const int ValueBelowRange = 5;
    private const int ValueAboveRange = 25;
    private const string ErrorMessage = "'value' in 'Product' should be in range 10 - 20.";

    [Test]
    public void ThrowIfNotRange_IntegerValueInsideRange_NoExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = ValueInsideRange;

        // Act
        Action action = () => ProductException.ThrowIfNotRange(min, max, value);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNotRange_IntegerValueBelowRange_ExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = ValueBelowRange;

        // Act
        Action action = () => ProductException.ThrowIfNotRange(min, max, value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfNotRange_ValueAboveRange_ExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = ValueAboveRange;

        // Act
        Action action = () => ProductException.ThrowIfNotRange(min, max, value);

        // Assert
        action.Should().
            Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfNotRange_ValueInMaxRange_NoExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = MaxValue;

        // Act
        Action action = () => ProductException.ThrowIfNotRange(min, max, value);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNotRange_ValueInMinRange_NoExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = MinValue;

        // Act
        Action action = () => ProductException.ThrowIfNotRange(min, max, value);

        // Assert
        action.Should().NotThrow<ProductException>();
    }
}

