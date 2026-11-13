namespace WorkerHub.ViewModels.Cart;

public class CartLine
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int WearSizeId { get; set; }
    public int WearColorId { get; set; }
    public string SizeName { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal LineTotal => Price * Quantity;
}
