﻿namespace Shop.Orders.Infrastructure.Mongo
{
    public class AddressData
    {
        public AddressData(string street,
            string city,
            string state,
            string country,
            string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }
    }
}
