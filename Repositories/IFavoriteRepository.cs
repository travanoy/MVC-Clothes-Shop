using WorkerHub.Models;

namespace WorkerHub.Repositories;

public interface IFavoriteRepository
{
    List<Favorite> GetForUser(string userId);
    bool IsFavorite(string userId, int productId);
    void Add(string userId, int productId);
    void Remove(string userId, int productId);
}
