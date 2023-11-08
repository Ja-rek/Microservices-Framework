namespace MicroservicesFramework.DesingByContract.Tests;

public class ThrowIfRangeTests
{
    private const int MinValue = 10;
    private const int MaxValue = 20;
    private const int ValueInsideRange = 15;
    private const int ValueBelowRange = 5;
    private const int ValueAboveRange = 25;
    private const string ErrorMessage = "'value' shouldn't be in range 10 - 20.";

    [Test]
    public void ThrowIfRange_ValueInsideRange_ExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = ValueInsideRange;

        // Act
        Action action = () => ProductException.ThrowIfRange(min, max, value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfRange_ValueBelowRange_NoExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = ValueBelowRange;

        // Act
        Action action = () => ProductException.ThrowIfRange(min, max, value);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfRange_ValueAboveRange_NoExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = ValueAboveRange;

        // Act
        Action action = () => ProductException.ThrowIfRange(min, max, value);

        // Assert
        action.Should().NotThrow<ProductException>();
    }


    [Test]
    public void ThrowIfRange_ValueInMaxRange_ExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = MaxValue;

        // Act
        Action action = () => ProductException.ThrowIfRange(min, max, value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfRange_ValueInMinRange_ExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var max = MaxValue;
        var value = MinValue;

        // Act
        Action action = () => ProductException.ThrowIfRange(min, max, value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }
}
