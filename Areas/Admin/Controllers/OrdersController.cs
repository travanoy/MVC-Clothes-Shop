using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Services;

namespace WorkerHub.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class OrdersController(IOrderService orderService) : Controller
{
    public IActionResult Index()
    {
        return View(orderService.GetAll());
    }

    [HttpPost]
    public IActionResult Complete(int id)
    {
        if (!orderService.Complete(id))
            return NotFound();

        return RedirectToAction(nameof(Index));
    }
}