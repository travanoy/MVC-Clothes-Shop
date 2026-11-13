using WorkerHub.Models;

namespace WorkerHub.Repositories;

public interface ICategoryRepository
{
    List<Category> Get();
    Category? Get(int id);
    void Add(Category category);
    void Update(Category category);
    void Delete(int id);
}
