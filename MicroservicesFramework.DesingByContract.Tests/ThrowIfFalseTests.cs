namespace MicroservicesFramework.DesingByContract.Tests;

[TestFixture]
public class ThrowIfFalseTests
{
    private const string errorMessage = "'value' shouldn't be false.";

    [Test]
    public void ThrowIfFalse_FalseValue_ExceptionThrown()
    {
        // Arrange
        bool value = false;

        // Act
        Action action = () => ProductException.ThrowIfFalse(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfFalse_TrueValue_NoExceptionThrown()
    {
        // Arrange
        bool value = true;

        // Act
        Action action = () => ProductException.ThrowIfFalse(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}

