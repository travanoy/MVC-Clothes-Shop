using WorkerHub.Repositories;
using WorkerHub.ViewModels.Products;

namespace WorkerHub.Services;

public class ProductService(IProductRepository repository) : IProductService
{
    public List<ProductListItem> GetAvailable(string? search)
    {
        var products = repository.GetAvailable()
            .Select(p => new ProductListItem
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                IsAvailable = p.IsAvailable,
                StockQuantity = p.StockQuantity,
                CategoryName = p.Category?.Name ?? string.Empty
            }).ToList();

        if (string.IsNullOrWhiteSpace(search))
            return products;

        return products.Where(p =>
            p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            p.CategoryName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            p.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public ProductDetails? GetDetails(int id)
    {
        var product = repository.Get(id);
        if (product is null)
            return null;

        var wearStocks = product.ProductWearStocks.Where(s => s.Quantity > 0).ToList();
        var sizes = new List<WearSizeOption>();
        var colors = new List<WearColorOption>();

        foreach (var stock in wearStocks)
        {
            if (!sizes.Any(s => s.Id == stock.WearSizeId))
                sizes.Add(new WearSizeOption { Id = stock.WearSizeId, Name = stock.WearSize!.Name });
            if (!colors.Any(c => c.Id == stock.WearColorId))
                colors.Add(new WearColorOption { Id = stock.WearColorId, Name = stock.WearColor!.Name, HexCode = stock.WearColor!.HexCode });
        }

        return new ProductDetails
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            StockQuantity = product.StockQuantity,
            IsAvailable = product.IsAvailable,
            CategoryId = product.CategoryId,
            CategoryName = product.Category!.Name,
            Sizes = sizes,
            Colors = colors
        };
    }
}