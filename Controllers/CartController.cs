using Microsoft.AspNetCore.Mvc;
using WorkerHub.Services;

namespace WorkerHub.Controllers;

public class CartController(ICartService cartService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var lines = cartService.GetLines();

        ViewBag.Total = lines.Sum(l => l.LineTotal);
        ViewBag.Notice = cartService.ConsumeNotice();

        return View(lines);
    }

    [HttpPost]
    public IActionResult AddToCart(int id, int wearSizeId, int wearColorId, string? returnUrl)
    {
        var result = cartService.Add(id, wearSizeId, wearColorId);
        if (result == CartAddStatus.ProductNotFound)
            return NotFound();

        return RedirectBack(returnUrl);
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int id, int wearSizeId, int wearColorId)
    {
        cartService.Remove(id, wearSizeId, wearColorId);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult ChangeQuantity(int id, int wearSizeId, int wearColorId, int delta)
    {
        cartService.ChangeQuantity(id, wearSizeId, wearColorId, delta);
        return RedirectToAction(nameof(Index));
    }

    private IActionResult RedirectBack(string? returnUrl)
    {
        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }
}