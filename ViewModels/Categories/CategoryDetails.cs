using WorkerHub.ViewModels.Products;

namespace WorkerHub.ViewModels.Categories;

public class CategoryDetails
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
    public List<ProductListItem> Products { get; set; } = new();
}
