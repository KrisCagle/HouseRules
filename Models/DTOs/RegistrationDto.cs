using System.ComponentModel.DataAnnotations;

namespace HouseRules.Models.DTOs;

public class RegistrationDTO
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [MaxLength(50, ErrorMessage = "Username must be 50 characters or less")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}