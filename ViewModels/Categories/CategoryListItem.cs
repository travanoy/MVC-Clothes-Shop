namespace WorkerHub.ViewModels.Categories;

public class CategoryListItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
    public int ProductsCount { get; set; }
}
