namespace MicroservicesFramework.DesingByContract.Tests;

public class ThrowIfGreaterThanTests
{
    private const int MinValue = 10;
    private const int LessThanMin = 5;
    private const int GreaterThanMin = 15;
    private const string ErrorMessage = "'value' in 'Product' shouldn't be greater than 10.";

    [Test]
    public void ThrowIfGreaterThan_ValueGreaterThanMin_ExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var value = GreaterThanMin;

        // Act
        Action action = () => ProductException.ThrowIfGreaterThan(min, value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(ErrorMessage);
    }

    [Test]
    public void ThrowIfGreaterThan_ValueEqualToMin_NoExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var value = MinValue;

        // Act
        Action action = () => ProductException.ThrowIfGreaterThan(min, value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfGreaterThan_ValueLessThanMin_NoExceptionThrown()
    {
        // Arrange
        var min = MinValue;
        var value = LessThanMin;

        // Act
        Action action = () => ProductException.ThrowIfGreaterThan(min, value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}
