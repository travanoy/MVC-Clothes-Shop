using WorkerHub.ViewModels.Products;

namespace WorkerHub.Services;

public interface IProductService
{
    List<ProductListItem> GetAvailable(string? search);
    ProductDetails? GetDetails(int id);
}