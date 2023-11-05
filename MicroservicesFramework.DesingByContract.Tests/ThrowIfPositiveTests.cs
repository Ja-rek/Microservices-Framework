namespace MicroservicesFramework.DesingByContract.Tests;

public class ThrowIfPositiveTests
{
    private const int PositiveValue = 10;
    private const int NegativeValue = -10;
    private const int ZeroValue = 0;
    private const string ErrorMessage = "'value' in 'Product' shouldn't be a positive number.";

    [Test]
    public void ThrowIfPositive_ValuePositive_ExceptionThrown()
    {
        // Arrange
        var value = PositiveValue;

        // Act
        Action action = () => ProductException.ThrowIfPositive(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfPositive_ValueNegative_NoExceptionThrown()
    {
        // Arrange
        var value = NegativeValue;

        // Act
        Action action = () => ProductException.ThrowIfPositive(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfPositive_ZeroValue_NoExceptionThrown()
    {
        // Arrange
        var value = ZeroValue;

        // Act
        Action action = () => ProductException.ThrowIfPositive(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}

