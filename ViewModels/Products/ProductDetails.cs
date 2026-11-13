namespace WorkerHub.ViewModels.Products;

public class ProductDetails
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
    public bool IsAvailable { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<WearSizeOption> Sizes { get; set; } = new();
    public List<WearColorOption> Colors { get; set; } = new();
}

public class WearSizeOption
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class WearColorOption
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HexCode { get; set; } = string.Empty;
}
