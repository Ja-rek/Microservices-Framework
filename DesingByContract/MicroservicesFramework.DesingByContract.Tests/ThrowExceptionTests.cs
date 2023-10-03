namespace MicroservicesFramework.DesingByContract.Tests;

internal class ThrowExceptionTests
{
    [Test]
    [TestCase((uint)55)]
    public void ThrowIfNotFound_WhenProdcutNotFound_ShouldThrowProductExceptiopnWithMessage(dynamic value)
    {
        long longnum = 9;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfPositive(longnum, 69);

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage($"Product with id 55 not found.");
    }

    [Test]
    public void ThrowIfNotFound_WhenPassCustomeMessage_ShouldThrowProductExceptiopnWithCustomeMessage()
    {
        Product test = null;
        var id = Guid.NewGuid();

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfNotFound(test, id, $"Not found an {nameof(Product)} with {nameof(id)}: {id}");

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage($"Not found an Product with id: {id}");
    }

    [Test]
    public void ThrowIfNotFound_WhenFountProduct_ShouldNotThrowProductExceptiopn()
    {
        var test = new Product(5, "name");
        var id = 5;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfNotFound(test, id);

        throwIfNotFound.Should()
            .NotThrow<ProductExceptiopn>();
    }

    [Test]
    public void ThrowIfIsPositive_WhenProdcutNotFound_ShouldThrowProductExceptiopnWithMessage()
    {
        var id = 96;
        var quantity = 5;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfPositive(quantity, id);

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage("Product id cannot be positive number. Passed value: 5");
    }

    [Test]
    public void ThrowIfIsPositive_WhenPassCustomeMessage_ShouldThrowProductExceptiopnWithCustomeMessage()
    {
        var id = 96;
        var quantity = 5;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfPositive(quantity, id, "Error message");

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage("Error message");
    }

    [Test]
    public void ThrowIfIsPositive_WhenFountProduct_ShouldNotThrowProductExceptiopn()
    {
        var id = 96;
        var quantity = 0;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfPositive(quantity, id);

        throwIfNotFound.Should()
            .NotThrow<ProductExceptiopn>();
    }

    [Test]
    public void ThrowIfIsNegative_WhenProdcutNotFound_ShouldThrowProductExceptiopnWithMessage()
    {
        var id = 96;
        var quantity = -5;

        //var throwIfNotFound = () => ProductExceptiopn.ThrowIfEmpty(null, id);
        //var throwIfNotFound = () => ProductExceptiopn.ThrowIfNegative(quantity);
        var throwIfNotFound = () => ProductExceptiopn.ThrowIf(quantity != 2, id);

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage("Product id cannot be negative number. Passed value: -5");
    }

    [Test]
    public void ThrowIfIsNegative_WhenPassCustomeMessage_ShouldThrowProductExceptiopnWithCustomeMessage()
    {
        var id = 96;
        var numer = -5;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfNegative(numer, id, "Error message");

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage("Error message");
    }

    [Test]
    public void ThrowIfIsNegative_WhenFountProduct_ShouldNotThrowProductExceptiopn()
    {
        var id = 5;
        var numer = 0;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfNegative(numer, id);

        throwIfNotFound.Should()
            .NotThrow<ProductExceptiopn>();
    }

    [Test]
    public void ThrowIfIsZero_WhenProdcutNotFound_ShouldThrowProductExceptiopnWithMessage()
    {
        var id = 0;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfZero(id, id);

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage("Product id cannot be zero.");
    }

    [Test]
    public void ThrowIfIsZero_WhenPassCustomeMessage_ShouldThrowProductExceptiopnWithCustomeMessage()
    {
        var id = 0;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfZero(id, "Error message");

        throwIfNotFound.Should()
            .Throw<ProductExceptiopn>()
            .WithMessage("Error message");
    }

    [Test]
    public void ThrowIfIsZero_WhenFountProduct_ShouldNotThrowProductExceptiopn()
    {
        var id = 5;

        var throwIfNotFound = () => ProductExceptiopn.ThrowIfZero(id, id);

        throwIfNotFound.Should()
            .NotThrow<ProductExceptiopn>();
    }

    [Test]
    public void Test()
    {
        var id = 0.5;
        var num = 1;

        var result = id.CompareTo(num) < 0;

        result.Should().BeTrue();
    }
}
