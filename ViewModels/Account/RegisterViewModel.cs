using System.ComponentModel.DataAnnotations;

namespace WorkerHub.ViewModels.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a password")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least {2} characters")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please confirm your password")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
