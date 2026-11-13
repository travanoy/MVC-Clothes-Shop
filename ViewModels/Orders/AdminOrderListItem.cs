namespace WorkerHub.ViewModels.Orders;

public class AdminOrderListItem
{
    public int Id { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<OrderItemLine> Items { get; set; } = new();
    public decimal Total => Items.Sum(i => i.LineTotal);
}
