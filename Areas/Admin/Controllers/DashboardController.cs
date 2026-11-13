using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Models;
using WorkerHub.Repositories;
using WorkerHub.ViewModels.Products;

namespace WorkerHub.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DashboardController(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IOrderRepository orderRepository,
    UserManager<ApplicationUser> userManager) : Controller
{
    public IActionResult Index()
    {
        var products = productRepository.Get().Select(p => new ProductListItem()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            IsAvailable = p.IsAvailable,
            CategoryName = p.Category?.Name ?? string.Empty
        }).ToList();

        ViewBag.ProductsCount = products.Count;
        ViewBag.AvailableProducts = products.Count(p => p.IsAvailable);
        ViewBag.CategoriesCount = categoryRepository.Get().Count;
        ViewBag.UsersCount = userManager.Users.Count();
        ViewBag.PendingOrders = orderRepository.Get().Count(o => o.Status == "Pending");

        return View(products);
    }
}
