using WorkerHub.ViewModels.Cart;
using WorkerHub.ViewModels.Orders;

namespace WorkerHub.Services;

public enum OrderCheckoutResult
{
    EmptyCart,
    NoValidItems,
    Success
}

public interface IOrderService
{
    List<OrderListItem> GetForUser(string userId);
    List<AdminOrderListItem> GetAll();
    OrderCheckoutResult Checkout(string userId, IEnumerable<CartItem> cartItems);
    bool Complete(int id);
}