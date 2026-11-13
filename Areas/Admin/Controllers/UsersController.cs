using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Models;
using WorkerHub.ViewModels.Account;

namespace WorkerHub.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UsersController(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        var users = userManager.Users.ToList();
        var model = new List<UserListItem>();

        var currentUser = await userManager.GetUserAsync(User);
        ViewBag.CurrentUserId = currentUser?.Id;

        foreach (var user in users)
        {
            model.Add(new UserListItem
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                IsAdmin = await userManager.IsInRoleAsync(user, "Admin"),
                IsLockedOut = await userManager.IsLockedOutAsync(user)
            });
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ToggleAdmin(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
            return NotFound();

        var currentUser = await userManager.GetUserAsync(User);
        if (currentUser is not null && currentUser.Id == user.Id)
            return RedirectToAction(nameof(Index));

        if (await userManager.IsInRoleAsync(user, "Admin"))
            await userManager.RemoveFromRoleAsync(user, "Admin");
        else
            await userManager.AddToRoleAsync(user, "Admin");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ToggleLock(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user is null)
            return NotFound();

        if (await userManager.IsLockedOutAsync(user))
        {
            await userManager.SetLockoutEndDateAsync(user, null);
        }
        else
        {
            await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
        }

        await signInManager.RefreshSignInAsync(user);

        return RedirectToAction(nameof(Index));
    }
}
