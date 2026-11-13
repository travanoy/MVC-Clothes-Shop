using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WorkerHub.Validation;

namespace WorkerHub.ViewModels.Categories;

public class CategoryForm
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter the category name")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The name must be between {2} and {1} characters")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description cannot exceed {1} characters")]
    public string Description { get; set; } = string.Empty;

    [BindNever]
    public string ImageUrl { get; set; } = string.Empty;

    [Display(Name = "Image")]
    [AllowedExtensions(".jpg", ".jpeg", ".png", ".webp")]
    public IFormFile? Image { get; set; }

    [Required(ErrorMessage = "Please enter the field")]
    [StringLength(50)]
    [Display(Name = "Field (e.g. Tops, Bottoms)")]
    public string Field { get; set; } = string.Empty;
}
