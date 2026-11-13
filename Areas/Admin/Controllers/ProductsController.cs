using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkerHub.Models;
using WorkerHub.Repositories;
using WorkerHub.Services;
using WorkerHub.ViewModels.Products;

namespace WorkerHub.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductsController(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IFileStorageService fileStorageService) : Controller
{
    public IActionResult Index()
    {
        var products = productRepository.Get().Select(p => new ProductListItem()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            SizeNames = DistinctSizeNames(p.ProductWearStocks),
            ColorNames = DistinctColorNames(p.ProductWearStocks),
            StockQuantity = p.StockQuantity,
            IsAvailable = p.IsAvailable,
            CategoryName = p.Category?.Name ?? string.Empty
        }).ToList();

        return View(products);
    }

    public IActionResult Create()
    {
        var stock = BuildStockMatrix(null);
        return View(new ProductForm()
        {
            Categories = LoadCategories(),
            Sizes = LoadSizes(),
            Colors = LoadColors(),
            Stock = stock,
            StockGrouped = GroupStock(stock)
        });
    }

    [HttpPost]
    public IActionResult Create(ProductForm form)
    {
        if (form.Image is null)
            ModelState.AddModelError("Image", "Please upload an image");

        if (!ModelState.IsValid)
        {
            form.Categories = LoadCategories();
            form.Sizes = LoadSizes();
            form.Colors = LoadColors();
            return View(form);
        }

        var imageUrl = fileStorageService.Save(form.Image!, "products");

        var product = new Product()
        {
            Name = form.Name,
            Description = form.Description,
            Price = form.Price,
            ImageUrl = imageUrl,
            StockQuantity = form.StockQuantity,
            IsAvailable = form.IsAvailable,
            CategoryId = form.CategoryId!.Value,
            ProductWearStocks = StocksFromForm(form.Stock)
        };

        productRepository.Add(product);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var product = productRepository.Get(id);
        if (product is null)
            return NotFound();

        var stock = BuildStockMatrix(product.ProductWearStocks);

        var form = new ProductForm()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            StockQuantity = product.StockQuantity,
            IsAvailable = product.IsAvailable,
            CategoryId = product.CategoryId,
            Categories = LoadCategories(),
            Sizes = LoadSizes(),
            Colors = LoadColors(),
            Stock = stock,
            StockGrouped = GroupStock(stock)
        };

        return View(form);
    }

    [HttpPost]
    public IActionResult Edit(int id, ProductForm form)
    {
        if (id != form.Id)
            return NotFound();

        if (!ModelState.IsValid)
        {
            form.Categories = LoadCategories();
            form.Sizes = LoadSizes();
            form.Colors = LoadColors();
            return View(form);
        }

        var imageUrl = form.ImageUrl;

        if (form.Image is not null)
        {
            fileStorageService.Delete(form.ImageUrl);
            imageUrl = fileStorageService.Save(form.Image, "products");
        }

        var product = new Product()
        {
            Id = form.Id,
            Name = form.Name,
            Description = form.Description,
            Price = form.Price,
            ImageUrl = imageUrl,
            ProductWearStocks = StocksFromForm(form.Stock),
            StockQuantity = form.StockQuantity,
            IsAvailable = form.IsAvailable,
            CategoryId = form.CategoryId!.Value
        };

        productRepository.Update(product);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var product = productRepository.Get(id);
        if (product is null)
            return NotFound();

        var model = new ProductListItem()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            SizeNames = DistinctSizeNames(product.ProductWearStocks),
            ColorNames = DistinctColorNames(product.ProductWearStocks),
            IsAvailable = product.IsAvailable
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = productRepository.Get(id);
        if (product is not null)
        {
            fileStorageService.Delete(product.ImageUrl);
            productRepository.Delete(id);
        }

        return RedirectToAction(nameof(Index));
    }

    private List<SelectListItem> LoadCategories()
    {
        return categoryRepository.Get()
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();
    }

    private List<SelectListItem> LoadSizes()
    {
        return productRepository.GetWearSizes()
            .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
            .ToList();
    }

    private List<SelectListItem> LoadColors()
    {
        return productRepository.GetWearColors()
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();
    }

    private List<ProductStockRow> BuildStockMatrix(List<ProductWearStock>? stocks)
    {
        var rows = new List<ProductStockRow>();

        foreach (var size in productRepository.GetWearSizes())
        {
            foreach (var color in productRepository.GetWearColors())
            {
                var stock = stocks?.FirstOrDefault(s =>
                    s.WearSizeId == size.Id && s.WearColorId == color.Id);

                rows.Add(new ProductStockRow
                {
                    SizeId = size.Id,
                    ColorId = color.Id,
                    Quantity = stock?.Quantity ?? 0
                });
            }
        }

        return rows;
    }

    private List<StockSizeRow> GroupStock(List<ProductStockRow> rows)
    {
        var grouped = new List<StockSizeRow>();

        foreach (var size in productRepository.GetWearSizes())
        {
            var row = new StockSizeRow { SizeId = size.Id, Name = size.Name };
            var index = 0;

            foreach (var srow in rows)
            {
                if (srow.SizeId == size.Id)
                {
                    row.Cells.Add(new StockColorCell
                    {
                        Index = index,
                        SizeId = srow.SizeId,
                        ColorId = srow.ColorId,
                        ColorName = productRepository.GetWearColors().First(c => c.Id == srow.ColorId).Name,
                        Quantity = srow.Quantity
                    });
                }

                index++;
            }

            grouped.Add(row);
        }

        return grouped;
    }

    private List<ProductWearStock> StocksFromForm(List<ProductStockRow> rows)
    {
        return rows
            .Where(r => r.Quantity > 0)
            .Select(r => new ProductWearStock { WearSizeId = r.SizeId, WearColorId = r.ColorId, Quantity = r.Quantity })
            .ToList();
    }

    private List<string> DistinctSizeNames(List<ProductWearStock> stocks)
    {
        var result = new List<string>();
        foreach (var stock in stocks)
        {
            if (stock.Quantity <= 0)
                continue;
            var name = stock.WearSize!.Name;
            if (!result.Contains(name))
                result.Add(name);
        }
        return result;
    }

    private List<string> DistinctColorNames(List<ProductWearStock> stocks)
    {
        var result = new List<string>();
        foreach (var stock in stocks)
        {
            if (stock.Quantity <= 0)
                continue;
            var name = stock.WearColor!.Name;
            if (!result.Contains(name))
                result.Add(name);
        }
        return result;
    }
}