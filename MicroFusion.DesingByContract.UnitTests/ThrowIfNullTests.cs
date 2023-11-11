namespace MicroFusion.DesingByContract.Tests;

[TestFixture]
public class ThrowIfNullTests
{
    private const string errorMessage = "'value' shouldn't be null.";

    [Test]
    public void ThrowIfNull_NonNullValue_NoExceptionThrown()
    {
        // Arrange
        var value = new object();

        // Act
        Action action = () => ProductException.ThrowIfNull(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNull_NullValue_ExceptionThrown()
    {
        // Arrange
        var value = (object)null;

        // Act
        Action action = () => ProductException.ThrowIfNull(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }
}

