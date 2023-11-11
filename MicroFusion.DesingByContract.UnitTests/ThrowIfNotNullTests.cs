namespace MicroFusion.DesingByContract.Tests;

[TestFixture]
public class ThrowIfNotNullTests
{
    private const string errorMessage = "'value' should be null.";

    [Test]
    public void ThrowIfNotNull_NullValue_NoExceptionThrown()
    {
        // Arrange
        var value = (object?)null;

        // Act
        Action action = () => ProductException.ThrowIfNotNull(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNotNull_NonNullValue_ExceptionThrown()
    {
        // Arrange
        var value = new object();

        // Act
        Action action = () => ProductException.ThrowIfNotNull(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }
}

