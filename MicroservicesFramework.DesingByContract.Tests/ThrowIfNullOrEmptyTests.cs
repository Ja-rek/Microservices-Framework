namespace MicroservicesFramework.DesingByContract.Tests;

[TestFixture]
public class ThrowIfNullOrEmptyTests
{
    private const string errorMessage = "'value' shouldn't not be null or empty.";

    [Test]
    public void ThrowIfNullOrEmpty_NullValue_ExceptionThrown()
    {
        // Arrange
        string? value = null;

        // Act
        Action action = () => ProductException.ThrowIfNullOrEmpty(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfNullOrEmpty_EmptyValue_ExceptionThrown()
    {
        // Arrange
        string? value = "";

        // Act
        Action action = () => ProductException.ThrowIfNullOrEmpty(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfNullOrEmpty_ValidValue_NoExceptionThrown()
    {
        // Arrange
        string? value = "ValidValue";

        // Act
        Action action = () => ProductException.ThrowIfNullOrEmpty(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}

