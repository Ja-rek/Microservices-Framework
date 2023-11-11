using MicroFusion.Domain.AbstractCore;
using Shop.Orders.Domain.Buyers.Exceptions;

namespace Shop.Orders.Domain.Orders;

public class Address : ValueObject
{
    public Address(string street,
        string city,
        string state,
        string country,
        string zipcode)
    {
        AddressException.ThrowIfIsNullOrWhiteSpace(street);
        AddressException.ThrowIfIsNullOrWhiteSpace(city);
        AddressException.ThrowIfIsNullOrWhiteSpace(state);
        AddressException.ThrowIfIsNullOrWhiteSpace(country);
        AddressException.ThrowIfIsNullOrWhiteSpace(zipcode);

        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipcode;
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
    }
}
