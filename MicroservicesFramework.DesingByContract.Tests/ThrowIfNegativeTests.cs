namespace MicroservicesFramework.DesingByContract.Tests;

public class ThrowIfNegativeTests
{
    private const int PositiveValue = 10;
    private const int NegativeValue = -10;
    private const int ZeroValue = 0;
    private const string ErrorMessage = "'value' in 'Product' shouldn't be a negative number.";

    [Test]
    public void ThrowIfNegative_ValuePositive_NoExceptionThrown()
    {
        // Arrange
        var value = PositiveValue;

        // Act
        Action action = () => ProductException.ThrowIfNegative(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNegative_ValueNegative_ExceptionThrown()
    {
        // Arrange
        var value = NegativeValue;

        // Act
        Action action = () => ProductException.ThrowIfNegative(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfNegative_ValueZero_NoExceptionThrown()
    {
        // Arrange
        var value = ZeroValue;

        // Act
        Action action = () => ProductException.ThrowIfNegative(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}

