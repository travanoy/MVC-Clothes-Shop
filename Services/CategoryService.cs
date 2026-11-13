using WorkerHub.Repositories;
using WorkerHub.ViewModels.Categories;
using WorkerHub.ViewModels.Products;

namespace WorkerHub.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    public List<CategoryListItem> GetAll()
    {
        return repository.Get().Select(c => new CategoryListItem
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ImageUrl = c.ImageUrl,
            Field = c.Field,
            ProductsCount = c.Products.Count
        }).ToList();
    }

    public CategoryDetails? GetDetails(int id)
    {
        var category = repository.Get(id);
        if (category is null)
            return null;

        return new CategoryDetails
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            Field = category.Field,
            Products = category.Products.Select(p => new ProductListItem
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                IsAvailable = p.IsAvailable,
                StockQuantity = p.StockQuantity,
                CategoryName = category.Name
            }).ToList()
        };
    }
}