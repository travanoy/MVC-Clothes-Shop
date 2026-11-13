namespace WorkerHub.ViewModels.Orders;

public class OrderItemLine
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SizeName { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal LineTotal => Price * Quantity;
}

public class OrderListItem
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<OrderItemLine> Items { get; set; } = new();
    public decimal Total => Items.Sum(i => i.LineTotal);
}
