namespace Shop.Orders.Application.Queries.Resources;

public record OrderResource
{
    public OrderResource(Guid id,
        DateTime date,
        string status,
        string description,
        string street,
        string city,
        string zipcode,
        string country,
        List<OrderItemResource> orderItems,
        decimal total)
    {
        Id = id;
        Date = date;
        Status = status;
        Description = description;
        Street = street;
        City = city;
        Zipcode = zipcode;
        Country = country;
        OrderItems = orderItems;
        Total = total;
    }

    public Guid Id { get; }
    public DateTime Date { get; }
    public string Status { get; }
    public string Description { get; }
    public string Street { get; }
    public string City { get; }
    public string Zipcode { get; }
    public string Country { get; }
    public List<OrderItemResource> OrderItems { get; }
    public decimal Total { get; }
}
