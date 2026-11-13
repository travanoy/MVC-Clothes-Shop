using Microsoft.AspNetCore.Identity;

namespace WorkerHub.Models;

public class ApplicationUser : IdentityUser
{
    public List<Order> Orders { get; set; } = new();
    public List<Favorite> Favorites { get; set; } = new();
}
