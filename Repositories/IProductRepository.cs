using WorkerHub.Models;

namespace WorkerHub.Repositories;

public interface IProductRepository
{
    List<Product> Get();
    List<Product> GetAvailable();
    Product? Get(int id);
    List<WearSize> GetWearSizes();
    List<WearColor> GetWearColors();
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
}
