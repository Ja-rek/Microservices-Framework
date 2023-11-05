using Shop.Orders.Domain.Buyers.Exceptions;
using Shop.Orders.Domain.Orders;

namespace Shop.Orders.Domain.UnitTests;

public class AddressTests
{
    private Fixture fixture;
    private string street;
    private string city;
    private string state;
    private string country;
    private string zipcode;

    [SetUp]
    public void SetUp()
    {
        fixture = new Fixture();
        street = "123 Main St";
        city = fixture.Create<string>();
        state = fixture.Create<string>();
        country = fixture.Create<string>();
        zipcode = fixture.Create<string>();
    }

    [Test]
    public void CreateAddress_WithEmptyStreet_ShouldThrowAddressException()
    {
        // Arrange
        street = string.Empty;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithNullStreet_ShouldThrowAddressException()
    {
        // Arrange
        street = null;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithWhitespaceStreet_ShouldThrowAddressException()
    {
        // Arrange
        street = "  "; // Whitespace

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithEmptyCity_ShouldThrowAddressException()
    {
        // Arrange
        city = string.Empty;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithNullCity_ShouldThrowAddressException()
    {
        // Arrange
        city = null;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithWhitespaceCity_ShouldThrowAddressException()
    {
        // Arrange
        city = "  "; // Whitespace

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithEmptyState_ShouldThrowAddressException()
    {
        // Arrange
        state = string.Empty;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithNullState_ShouldThrowAddressException()
    {
        // Arrange
        state = null;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithWhitespaceState_ShouldThrowAddressException()
    {
        // Arrange
        state = "  "; // Whitespace

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithEmptyCountry_ShouldThrowAddressException()
    {
        // Arrange
        country = string.Empty;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithNullCountry_ShouldThrowAddressException()
    {
        // Arrange
        country = null;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithWhitespaceCountry_ShouldThrowAddressException()
    {
        // Arrange
        country = "  "; // Whitespace

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithEmptyZipCode_ShouldThrowAddressException()
    {
        // Arrange
        zipcode = string.Empty;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithNullZipCode_ShouldThrowAddressException()
    {
        // Arrange
        zipcode = null;

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    [Test]
    public void CreateAddress_WithWhitespaceZipCode_ShouldThrowAddressException()
    {
        // Arrange
        zipcode = "  "; // Whitespace

        // Act
        Action act = () => CreateAddress();

        // Assert
        act.Should().Throw<AddressException>();
    }

    private Address CreateAddress()
    {
        return new Address(street, city, state, country, zipcode);
    }
}

