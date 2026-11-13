namespace WorkerHub.ViewModels.Shared;

public class NavbarViewModel
{
    public bool IsSignedIn { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int CartCount { get; set; }
}
