namespace MicroservicesFramework.DesingByContract.Tests;

[TestFixture]
public class ThrowIfTests
{
    [Test]
    public void ThrowIf_True_ExceptionThrown()
    {
        // Act & Arrange
        Action action = () => ProductException.ThrowIf(2 == 2);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage("'2 == 2' shouldn't be true.");

    }

    [Test]
    public void ThrowIf_False_NoExceptionThrown()
    {
        // Act & Arrange
        Action action = () => ProductException.ThrowIf(2 != 2);

        // Assert
        action.Should().NotThrow<ProductException>();
    }
}
