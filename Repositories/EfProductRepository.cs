using WorkerHub.Models;
using WorkerHub.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkerHub.Repositories;

public class EfProductRepository(AppDbContext context) : IProductRepository
{
    public List<Product> Get() => context.Products
        .Include(p => p.Category)
        .Include(p => p.ProductWearStocks).ThenInclude(pws => pws.WearSize)
        .Include(p => p.ProductWearStocks).ThenInclude(pws => pws.WearColor)
        .ToList();

    public List<Product> GetAvailable() => context.Products
        .Include(p => p.Category)
        .Include(p => p.ProductWearStocks).ThenInclude(pws => pws.WearSize)
        .Include(p => p.ProductWearStocks).ThenInclude(pws => pws.WearColor)
        .Where(p => p.IsAvailable)
        .ToList();

    public Product? Get(int id) => context.Products
        .Include(p => p.Category)
        .Include(p => p.ProductWearStocks).ThenInclude(pws => pws.WearSize)
        .Include(p => p.ProductWearStocks).ThenInclude(pws => pws.WearColor)
        .FirstOrDefault(p => p.Id == id);

    public List<WearSize> GetWearSizes()
    {
        return context.WearSizes.OrderBy(w => w.Name).ToList();
    }

    public List<WearColor> GetWearColors()
    {
        return context.WearColors.OrderBy(w => w.Name).ToList();
    }

    public void Add(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void Update(Product product)
    {
        var existing = context.Products
            .Include(p => p.ProductWearStocks)
            .FirstOrDefault(p => p.Id == product.Id);

        if (existing is not null)
        {
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.ImageUrl = product.ImageUrl;
            existing.StockQuantity = product.StockQuantity;
            existing.IsAvailable = product.IsAvailable;
            existing.CategoryId = product.CategoryId;
            existing.Category = product.Category;

            existing.ProductWearStocks.Clear();
            foreach (var pws in product.ProductWearStocks)
                existing.ProductWearStocks.Add(new ProductWearStock { WearSizeId = pws.WearSizeId, WearColorId = pws.WearColorId, Quantity = pws.Quantity });

            context.Products.Update(existing);
        }

        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = context.Products.Find(id);
        if (product is not null)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
