using System.ComponentModel.DataAnnotations;

namespace WorkerHub.Validation;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedExtensionsAttribute(params string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is null)
            return ValidationResult.Success;

        if (value is not IFormFile file)
            return ValidationResult.Success;

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!_extensions.Contains(extension))
        {
            return new ValidationResult(
                $"Allowed formats: {string.Join(", ", _extensions)}");
        }

        return ValidationResult.Success;
    }
}
