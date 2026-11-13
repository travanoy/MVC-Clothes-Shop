using WorkerHub.Models;
using WorkerHub.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkerHub.Repositories;

public class EfFavoriteRepository(AppDbContext context) : IFavoriteRepository
{
    public List<Favorite> GetForUser(string userId) => context.Favorites
        .Include(f => f.Product)
            .ThenInclude(p => p!.Category)
        .Where(f => f.UserId == userId)
        .ToList();

    public bool IsFavorite(string userId, int productId) => context.Favorites
        .Any(f => f.UserId == userId && f.ProductId == productId);

    public void Add(string userId, int productId)
    {
        if (IsFavorite(userId, productId))
            return;

        context.Favorites.Add(new Favorite { UserId = userId, ProductId = productId });
        context.SaveChanges();
    }

    public void Remove(string userId, int productId)
    {
        var favorite = context.Favorites
            .FirstOrDefault(f => f.UserId == userId && f.ProductId == productId);

        if (favorite is not null)
        {
            context.Favorites.Remove(favorite);
            context.SaveChanges();
        }
    }
}
