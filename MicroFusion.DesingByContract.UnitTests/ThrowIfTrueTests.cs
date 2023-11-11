namespace MicroFusion.DesingByContract.Tests;

[TestFixture]
public class ThrowIfTrueTests
{
    private const string TrueMessage = "'value' shouldn't be true.";

    [Test]
    public void ThrowIfTrue_TrueValue_ExceptionThrown()
    {
        // Arrange
        bool value = true;

        // Act
        Action action = () => ProductException.ThrowIfTrue(value);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(TrueMessage);
    }

    [Test]
    public void ThrowIfTrue_FalseValue_NoExceptionThrown()
    {
        // Arrange
        bool value = false;

        // Act
        Action action = () => ProductException.ThrowIfTrue(value);

        // Assert
        action.Should()
            .NotThrow<ProductException>();
    }
}
