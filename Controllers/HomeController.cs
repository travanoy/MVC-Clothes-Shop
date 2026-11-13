using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Services;

namespace WorkerHub.Controllers;

public class HomeController(IProductService productService, IFavoriteService favoriteService) : Controller
{
    [HttpGet]
    public IActionResult Index(string? search)
    {
        var products = productService.GetAvailable(search);

        ViewBag.Search = search ?? string.Empty;
        ViewBag.FavoriteIds = GetFavoriteIds();

        return View(products);
    }

    private List<int> GetFavoriteIds()
    {
        if (User.Identity?.IsAuthenticated != true)
            return new List<int>();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        return favoriteService.GetProductIdsForUser(userId);
    }
}