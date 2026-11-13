namespace WorkerHub.ViewModels.Products;

public class ProductListItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> SizeNames { get; set; } = new();
    public List<string> ColorNames { get; set; } = new();
    public int StockQuantity { get; set; }
    public bool IsAvailable { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
