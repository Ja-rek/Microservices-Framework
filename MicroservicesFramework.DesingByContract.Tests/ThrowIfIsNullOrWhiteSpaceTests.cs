namespace MicroservicesFramework.DesingByContract.Tests;

[TestFixture]
public class ThrowIfIsNullOrWhiteSpaceTests
{
    private const string errorMessage = "'value' shouldn't be null, empty or white space.";

    [Test]
    public void ThrowIfIsNullOrWhiteSpace_NullValue_ExceptionThrown()
    {
        // Arrange
        var value = (string?)null;

        // Act
        Action action = () => ProductException.ThrowIfIsNullOrWhiteSpace(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfIsNullOrWhiteSpace_EmptyValue_ExceptionThrown()
    {
        // Arrange
        var value = "";

        // Act
        Action action = () => ProductException.ThrowIfIsNullOrWhiteSpace(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfIsNullOrWhiteSpace_WhiteSpaceValue_ExceptionThrown()
    {
        // Arrange
        var value = "   ";

        // Act
        Action action = () => ProductException.ThrowIfIsNullOrWhiteSpace(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfIsNullOrWhiteSpace_ValidValue_NoExceptionThrown()
    {
        // Arrange
        var value = "ValidValue";

        // Act
        Action action = () => ProductException.ThrowIfIsNullOrWhiteSpace(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}

