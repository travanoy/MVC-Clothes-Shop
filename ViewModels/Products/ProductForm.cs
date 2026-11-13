using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkerHub.Validation;

namespace WorkerHub.ViewModels.Products;

public class ProductForm
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter the product name")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The name must be between {2} and {1} characters")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description cannot exceed {1} characters")]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 10_000, ErrorMessage = "Price must be between {1} and {2}")]
    [Display(Name = "Price ($)")]
    public decimal Price { get; set; }

    [BindNever]
    public string ImageUrl { get; set; } = string.Empty;

    [Display(Name = "Image")]
    [AllowedExtensions(".jpg", ".jpeg", ".png", ".webp")]
    public IFormFile? Image { get; set; }

    public List<ProductStockRow> Stock { get; set; } = new();
    public List<StockSizeRow> StockGrouped { get; set; } = new();

    public List<SelectListItem> Sizes { get; set; } = new();
    public List<SelectListItem> Colors { get; set; } = new();

    [Range(0, 10_000, ErrorMessage = "Stock must be between {1} and {2}")]
    [Display(Name = "Stock quantity")]
    public int StockQuantity { get; set; }

    [Display(Name = "Available")]
    public bool IsAvailable { get; set; }

    [Required(ErrorMessage = "Please select a category")]
    public int? CategoryId { get; set; }

    public List<SelectListItem> Categories { get; set; } = new();
}

public class ProductStockRow
{
    public int SizeId { get; set; }
    public int ColorId { get; set; }
    public int Quantity { get; set; }
}

public class StockSizeRow
{
    public int SizeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<StockColorCell> Cells { get; set; } = new();
}

public class StockColorCell
{
    public int Index { get; set; }
    public int SizeId { get; set; }
    public int ColorId { get; set; }
    public string ColorName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
