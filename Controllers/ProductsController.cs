using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Services;

namespace WorkerHub.Controllers;

public class ProductsController(IProductService productService, IFavoriteService favoriteService, ICartService cartService) : Controller
{
    [HttpGet]
    public IActionResult Details(int id)
    {
        var model = productService.GetDetails(id);

        if (model is null)
            return NotFound();

        ViewBag.IsFavorite = IsFavorite(model.Id);
        ViewBag.Notice = cartService.ConsumeNotice();
        return View(model);
    }

    private bool IsFavorite(int productId)
    {
        if (User.Identity?.IsAuthenticated != true)
            return false;

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        return favoriteService.IsFavorite(userId, productId);
    }
}