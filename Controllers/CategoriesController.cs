using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Services;

namespace WorkerHub.Controllers;

public class CategoriesController(ICategoryService categoryService, IFavoriteService favoriteService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(categoryService.GetAll());
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var model = categoryService.GetDetails(id);

        if (model is null)
            return NotFound();

        ViewBag.FavoriteIds = GetFavoriteIds();

        return View(model);
    }

    private List<int> GetFavoriteIds()
    {
        if (User.Identity?.IsAuthenticated != true)
            return new List<int>();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        return favoriteService.GetProductIdsForUser(userId);
    }
}