using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entity.ViewModel;

public class AddUserDetail
{
    [Required(ErrorMessage = "Role is required")]
    public int Roleid { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string Firstname { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    public string Lastname { get; set; } = null!;
    [Required(ErrorMessage = "User name is required")]
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "password is required")]
    public string Password { get; set; } = null!;
    public IFormFile ProfileImageFile{get; set; }
    public string ProfileimagePath { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    
    public string Phonenumber { get; set; } = null!;
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;
    [Required(ErrorMessage = "Zipcode is required")]
    public string Zipcode { get; set; } = null!;
    public bool Status { get; set; }
    [Required(ErrorMessage = "Country is required")]
    public int Countryid { get; set; }
    [Required(ErrorMessage = "State is required")]
    public int Stateid { get; set; }
    [Required(ErrorMessage = "City is required")]
    public int Cityid { get; set; }
}
