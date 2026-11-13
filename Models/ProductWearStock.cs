namespace WorkerHub.Models;

public class ProductWearStock
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int WearSizeId { get; set; }
    public WearSize? WearSize { get; set; }
    public int WearColorId { get; set; }
    public WearColor? WearColor { get; set; }
    public int Quantity { get; set; }
}