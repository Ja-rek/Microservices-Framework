namespace Shop.Orders.Application.Queries.Resources;

public record OrderSummaryResource
{
    public OrderSummaryResource(Guid id,
        DateTime date,
        string status,
        decimal total)
    {
        Id = id;
        Date = date;
        Status = status;
        Total = total;
    }

    public Guid Id { get; }
    public DateTime Date { get; }
    public string Status { get; }
    public decimal Total { get; }
}
