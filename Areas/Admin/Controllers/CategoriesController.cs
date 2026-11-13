using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkerHub.Models;
using WorkerHub.Repositories;
using WorkerHub.Services;
using WorkerHub.ViewModels.Categories;

namespace WorkerHub.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CategoriesController(ICategoryRepository repository, IFileStorageService fileStorageService) : Controller
{
    public IActionResult Index()
    {
        var categories = repository.Get().Select(c => new CategoryListItem()
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ImageUrl = c.ImageUrl,
            Field = c.Field,
            ProductsCount = c.Products.Count
        }).ToList();

        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CategoryForm form)
    {
        if (form.Image is null)
            ModelState.AddModelError("Image", "Please upload an image");

        if (!ModelState.IsValid)
            return View(form);

        var imageUrl = fileStorageService.Save(form.Image!, "categories");

        repository.Add(new Category()
        {
            Name = form.Name,
            Description = form.Description,
            ImageUrl = imageUrl,
            Field = form.Field
        });

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var category = repository.Get(id);
        if (category is null)
            return NotFound();

        var model = new CategoryForm()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            Field = category.Field
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(int id, CategoryForm form)
    {
        if (id != form.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(form);

        var imageUrl = form.ImageUrl;

        if (form.Image is not null)
        {
            fileStorageService.Delete(form.ImageUrl);
            imageUrl = fileStorageService.Save(form.Image, "categories");
        }

        repository.Update(new Category()
        {
            Id = form.Id,
            Name = form.Name,
            Description = form.Description,
            ImageUrl = imageUrl,
            Field = form.Field
        });

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var category = repository.Get(id);
        if (category is null)
            return NotFound();

        var model = new CategoryListItem()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            Field = category.Field,
            ProductsCount = category.Products.Count
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var category = repository.Get(id);
        if (category is not null)
        {
            foreach (var product in category.Products)
                fileStorageService.Delete(product.ImageUrl);

            fileStorageService.Delete(category.ImageUrl);
            repository.Delete(id);
        }

        return RedirectToAction(nameof(Index));
    }
}
