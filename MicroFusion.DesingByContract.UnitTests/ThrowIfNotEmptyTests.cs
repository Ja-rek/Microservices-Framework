namespace MicroFusion.DesingByContract.Tests;

[TestFixture]
public class ThrowIfNotEmptyTests
{
    [Test]
    public void ThrowIfNotEmpty_ListNotNotEmpty_ExceptionThrown()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };
        var errorMessage = CreateNotEmptyMessage(nameof(list));

        // Act
        Action action = () => ProductException.ThrowIfNotEmpty(list);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfNotEmpty_ListNotEmpty_NoExceptionThrown()
    {
        // Arrange
        var emptyList = new List<int>();

        // Act
        Action action = () => ProductException.ThrowIfNotEmpty(emptyList);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    [Test]
    public void ThrowIfNotEmpty_StringNotNotEmpty_ExceptionThrown()
    {
        // Arrange
        var notEmptyString = "Hello";
        var errorMessage = CreateNotEmptyMessage(nameof(notEmptyString));

        // Act
        Action action = () => ProductException.ThrowIfNotEmpty(notEmptyString);

        // Assert
        action.Should()
            .Throw<ProductException>()
            .WithMessage(errorMessage);
    }

    [Test]
    public void ThrowIfNotEmpty_NotEmptyString_NoExceptionThrown()
    {
        // Arrange
        var emptyString = string.Empty;

        // Act
        Action action = () => ProductException.ThrowIfNotEmpty(emptyString);

        // Assert
        action.Should().NotThrow<ProductException>();
    }

    private string CreateNotEmptyMessage(string paramName) =>
        $"'{paramName}' should be empty.";
}

