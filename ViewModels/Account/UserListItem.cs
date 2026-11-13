namespace WorkerHub.ViewModels.Account;

public class UserListItem
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
    public bool IsLockedOut { get; set; }
}
