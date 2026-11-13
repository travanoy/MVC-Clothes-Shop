using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Services;

namespace WorkerHub.Controllers;

[Authorize]
public class FavoritesController(IFavoriteService favoriteService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        return View(favoriteService.GetForUser(userId));
    }

    [HttpPost]
    public IActionResult Toggle(int id, string? returnUrl)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        favoriteService.Toggle(userId, id);
        var isFavorite = favoriteService.IsFavorite(userId, id);

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            return Json(new { isFavorite });

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }
}