using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Models;
using WorkerHub.Services;
using WorkerHub.ViewModels.Shared;

namespace WorkerHub.Components;

public class NavbarViewComponent(
    SignInManager<ApplicationUser> signInManager,
    ICartService cartService) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new NavbarViewModel
        {
            IsSignedIn = signInManager.IsSignedIn(UserClaimsPrincipal),
            UserName = UserClaimsPrincipal.Identity?.Name ?? string.Empty,
            CartCount = cartService.Count()
        };

        return View(model);
    }
}