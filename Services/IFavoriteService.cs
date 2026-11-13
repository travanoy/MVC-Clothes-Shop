using WorkerHub.ViewModels.Favorites;

namespace WorkerHub.Services;

public interface IFavoriteService
{
    List<FavoriteListItem> GetForUser(string userId);
    List<int> GetProductIdsForUser(string userId);
    bool IsFavorite(string userId, int productId);
    void Toggle(string userId, int productId);
}