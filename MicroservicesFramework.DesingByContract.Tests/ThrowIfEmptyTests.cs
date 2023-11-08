namespace MicroservicesFramework.DesingByContract.Tests;

[TestFixture]
public class ThrowIfEmptyTests
{
    [Test]
    public void ThrowIfEmpty_ListNotEmpty_NoExceptionThrown()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };

        // Act
        Action action = () => ProductException.ThrowIfEmpty(list);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfEmpty_ListEmpty_ExceptionThrown()
    {
        // Arrange
        var emptyList = new List<int>();
        var errorMessage = CreateEmptyMessage(nameof(emptyList));

        // Act
        Action action = () => ProductException.ThrowIfEmpty(emptyList);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfEmpty_StringNotEmpty_NoExceptionThrown()
    {
        // Arrange
        var nonEmptyString = "Hello";

        // Act
        Action action = () => ProductException.ThrowIfEmpty(nonEmptyString);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfEmpty_EmptyString_ExceptionThrown()
    {
        // Arrange
        var emptyString = string.Empty;
        var errorMessage = CreateEmptyMessage(nameof(emptyString));

        // Act
        Action action = () => ProductException.ThrowIfEmpty(emptyString);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    private string CreateEmptyMessage(string paramName) =>
        $"'{paramName}' shouldn't be empty.";
}

