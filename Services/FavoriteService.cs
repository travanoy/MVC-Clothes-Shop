using WorkerHub.Repositories;
using WorkerHub.ViewModels.Favorites;

namespace WorkerHub.Services;

public class FavoriteService(IFavoriteRepository repository) : IFavoriteService
{
    public List<FavoriteListItem> GetForUser(string userId)
    {
        return repository.GetForUser(userId)
            .Select(f => new FavoriteListItem
            {
                ProductId = f.Product!.Id,
                Name = f.Product.Name,
                Description = f.Product.Description,
                Price = f.Product.Price,
                ImageUrl = f.Product.ImageUrl,
                CategoryName = f.Product.Category?.Name ?? string.Empty
            }).ToList();
    }

    public List<int> GetProductIdsForUser(string userId)
    {
        return repository.GetForUser(userId).Select(f => f.ProductId).ToList();
    }

    public bool IsFavorite(string userId, int productId)
    {
        return repository.IsFavorite(userId, productId);
    }

    public void Toggle(string userId, int productId)
    {
        if (repository.IsFavorite(userId, productId))
            repository.Remove(userId, productId);
        else
            repository.Add(userId, productId);
    }
}