using WorkerHub.ViewModels.Orders;

namespace WorkerHub.ViewModels.Account;

public class ProfileViewModel
{
    public string Email { get; set; } = string.Empty;
    public List<OrderListItem> Orders { get; set; } = new();
}
