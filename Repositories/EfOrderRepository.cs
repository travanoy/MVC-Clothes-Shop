using WorkerHub.Models;
using WorkerHub.Data;
using Microsoft.EntityFrameworkCore;

namespace WorkerHub.Repositories;

public class EfOrderRepository(AppDbContext context) : IOrderRepository
{
    public List<Order> Get() => context.Orders
        .Include(o => o.User)
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.WearSize)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.WearColor)
        .OrderByDescending(o => o.CreatedAt)
        .ToList();

    public List<Order> GetForUser(string userId) => context.Orders
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.WearSize)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.WearColor)
        .Where(o => o.UserId == userId)
        .OrderByDescending(o => o.CreatedAt)
        .ToList();

    public Order? Get(int id) => context.Orders
        .Include(o => o.User)
        .FirstOrDefault(o => o.Id == id);

    public Order? GetWithItems(int id) => context.Orders
        .Include(o => o.User)
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.WearSize)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.WearColor)
        .FirstOrDefault(o => o.Id == id);

    public void Add(Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
    }

    public void Update(Order order)
    {
        context.Orders.Update(order);
        context.SaveChanges();
    }
}
