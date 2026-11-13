using WorkerHub.Models;

namespace WorkerHub.Repositories;

public interface IOrderRepository
{
    List<Order> Get();
    List<Order> GetForUser(string userId);
    Order? Get(int id);
    Order? GetWithItems(int id);
    void Add(Order order);
    void Update(Order order);
}
