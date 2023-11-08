namespace MicroservicesFramework.DesingByContract.Tests;

[TestFixture]
public class ThrowIfDefaultTests
{
    private const string errorMessage = "'value' shouldn't be default.";

    [Test]
    public void ThrowIfDefault_DefaultValue_ExceptionThrown()
    {
        // Arrange
        int value = default;

        // Act
        Action action = () => ProductException.ThrowIfDefault(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfDefault_NonDefaultValue_NoExceptionThrown()
    {
        // Arrange
        int value = 42;

        // Act
        Action action = () => ProductException.ThrowIfDefault(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfDefault_DefaultReferenceValue_ExceptionThrown()
    {
        // Arrange
        string value = default;

        // Act
        Action action = () => ProductException.ThrowIfDefault(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfDefault_NonDefaultReferenceValue_NoExceptionThrown()
    {
        // Arrange
        string value = "Hello";

        // Act
        Action action = () => ProductException.ThrowIfDefault(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}

