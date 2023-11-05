namespace MicroservicesFramework.DesingByContract.Tests;

public class ThrowIfNotZeroTests
{
    private const int ZeroValue = 0;
    private const int NonZeroValue = 10;
    private const int NegativeValue = -10;
    private const string ErrorMessage = "'value' in 'Product' should be zero.";

    [Test]
    public void ThrowIfNotZero_ValueZero_NoExceptionThrown()
    {
        // Arrange
        var value = ZeroValue;

        // Act
        Action action = () => ProductException.ThrowIfNotZero(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNotZero_ValueNonZero_ExceptionThrown()
    {
        // Arrange
        var value = NonZeroValue;

        // Act
        Action action = () => ProductException.ThrowIfNotZero(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfNotZero_NegativeValue_ExceptionThrown()
    {
        // Arrange
        var value = NegativeValue;

        // Act
        Action action = () => ProductException.ThrowIfNotZero(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }
}

