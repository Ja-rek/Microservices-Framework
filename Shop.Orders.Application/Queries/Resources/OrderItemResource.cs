namespace Shop.Orders.Application.Queries.Resources;

public record OrderItemResource
{
    public OrderItemResource(string productname,
        int units,
        double unitprice,
        string pictureurl)
    {
        this.productname = productname;
        this.units = units;
        this.unitprice = unitprice;
        this.pictureurl = pictureurl;
    }

    public string productname { get; }
    public int units { get; }
    public double unitprice { get; }
    public string pictureurl { get; }
}
