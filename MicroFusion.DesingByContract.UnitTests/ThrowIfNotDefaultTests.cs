namespace MicroFusion.DesingByContract.Tests;

[TestFixture]
public class ThrowIfNotDefaultTests
{
    private const string errorMessage = "'value' should be default.";

    [Test]
    public void ThrowIfNotDefault_DefaultValue_NoExceptionThrown()
    {
        // Arrange
        int value = default;

        // Act
        Action action = () => ProductException.ThrowIfNotDefault(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNotDefault_NonDefaultValue_ExceptionThrown()
    {
        // Arrange
        int value = 42;

        // Act
        Action action = () => ProductException.ThrowIfNotDefault(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfNotDefault_DefaultReferenceValue_NoExceptionThrown()
    {
        // Arrange
        string value = default;

        // Act
        Action action = () => ProductException.ThrowIfNotDefault(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNotDefault_NonDefaultReferenceValue_ExceptionThrown()
    {
        // Arrange
        string value = "Hello";

        // Act
        Action action = () => ProductException.ThrowIfNotDefault(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }
}

