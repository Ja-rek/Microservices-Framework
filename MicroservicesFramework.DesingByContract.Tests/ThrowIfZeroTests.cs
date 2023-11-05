namespace MicroservicesFramework.DesingByContract.Tests;

public class ThrowIfZeroTests
{
    private const int ZeroValue = 0;
    private const int NotZeroValue = 69;
    private const int NegativeValue = -10;
    private const string ErrorMessage = "'value' in 'Product' should be zero.";

    [Test]
    public void ThrowIfZero_ValueNotZero_NoExceptionThrown()
    {
        // Arrange
        var value = NotZeroValue;

        // Act
        Action action = () => ProductException.ThrowIfZero(value);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfZero_ValueZero_ExceptionThrown()
    {
        // Arrange
        var value = ZeroValue;

        // Act
        Action action = () => ProductException.ThrowIfZero(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfZero_NegativeValue_NoExceptionThrown()
    {
        // Arrange
        var value = NegativeValue;

        // Act
        Action action = () => ProductException.ThrowIfZero(value);

        // Assert
        action.Should().NotThrow<ProductException>();
    }
}

