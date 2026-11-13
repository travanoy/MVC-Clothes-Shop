using WorkerHub.Models;
using WorkerHub.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkerHub.Repositories;

public class EfCategoryRepository(AppDbContext context) : ICategoryRepository
{
    public List<Category> Get() => context.Categories.ToList();

    public Category? Get(int id) => context.Categories
        .Include(c => c.Products)
        .FirstOrDefault(c => c.Id == id);

    public void Add(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
    }

    public void Update(Category category)
    {
        context.Categories.Update(category);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var category = context.Categories.Find(id);
        if (category is not null)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
