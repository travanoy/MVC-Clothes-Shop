using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Models;
using WorkerHub.Services;

namespace WorkerHub.Controllers;

[Authorize]
public class OrdersController(
    IOrderService orderService,
    ICartService cartService,
    UserManager<ApplicationUser> userManager) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var userId = userManager.GetUserId(User) ?? string.Empty;
        return View(orderService.GetForUser(userId));
    }

    [HttpPost]
    public IActionResult Checkout()
    {
        var userId = userManager.GetUserId(User) ?? string.Empty;
        var cart = cartService.GetItems();

        var result = orderService.Checkout(userId, cart);
        if (result == OrderCheckoutResult.EmptyCart || result == OrderCheckoutResult.NoValidItems)
            return RedirectToAction("Index", "Cart");

        cartService.Clear();

        return RedirectToAction(nameof(Index));
    }
}