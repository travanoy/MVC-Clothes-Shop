using WorkerHub.Models;
using WorkerHub.Repositories;
using WorkerHub.ViewModels.Cart;
using WorkerHub.ViewModels.Orders;

namespace WorkerHub.Services;

public class OrderService(IOrderRepository orderRepository, IProductRepository productRepository) : IOrderService
{
    public List<OrderListItem> GetForUser(string userId)
    {
        return orderRepository.GetForUser(userId)
            .Select(ToOrderListItem)
            .ToList();
    }

    public List<AdminOrderListItem> GetAll()
    {
        return orderRepository.Get()
            .Select(o => new AdminOrderListItem
            {
                Id = o.Id,
                UserEmail = o.User?.Email ?? string.Empty,
                CreatedAt = o.CreatedAt,
                Status = o.Status,
                Items = o.OrderItems.Select(ToOrderItemLine).ToList()
            }).ToList();
    }

    public OrderCheckoutResult Checkout(string userId, IEnumerable<CartItem> cartItems)
    {
        var cart = cartItems.Where(c => c.Quantity > 0).ToList();
        if (cart.Count == 0)
            return OrderCheckoutResult.EmptyCart;

        var order = new Order
        {
            UserId = userId,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow,
            OrderItems = new List<OrderItem>()
        };

        foreach (var entry in cart)
        {
            var product = productRepository.Get(entry.ProductId);
            if (product is null || !product.IsAvailable)
                continue;

            var stock = product.ProductWearStocks.FirstOrDefault(s =>
                s.WearSizeId == entry.WearSizeId && s.WearColorId == entry.WearColorId);

            var maxQuantity = stock?.Quantity ?? 0;
            var quantity = Math.Min(entry.Quantity, maxQuantity);
            if (quantity <= 0)
                continue;

            order.OrderItems.Add(new OrderItem
            {
                ProductId = product.Id,
                WearSizeId = entry.WearSizeId,
                WearColorId = entry.WearColorId,
                Quantity = quantity,
                Price = product.Price
            });
        }

        if (order.OrderItems.Count == 0)
            return OrderCheckoutResult.NoValidItems;

        orderRepository.Add(order);
        return OrderCheckoutResult.Success;
    }

    public bool Complete(int id)
    {
        var order = orderRepository.Get(id);
        if (order is null)
            return false;

        if (order.Status == "Pending")
        {
            order.Status = "Completed";
            orderRepository.Update(order);
        }

        return true;
    }

    private static OrderListItem ToOrderListItem(Order order) => new()
    {
        Id = order.Id,
        Status = order.Status,
        CreatedAt = order.CreatedAt,
        Items = order.OrderItems.Select(ToOrderItemLine).ToList()
    };

    private static OrderItemLine ToOrderItemLine(OrderItem item) => new()
    {
        ProductId = item.ProductId,
        Name = item.Product?.Name ?? "Product",
        SizeName = item.WearSize?.Name ?? string.Empty,
        ColorName = item.WearColor?.Name ?? string.Empty,
        Quantity = item.Quantity,
        Price = item.Price
    };
}