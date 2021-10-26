using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AirportCodes.Models
{
    public class ApplicationUser : IdentityUser
    {
    [Required]
    [StringLength(20, ErrorMessage = "Maximum amount of characters for the username is 20")]
    public override string UserName { get; set; }
    [Required]
    public override string Email { get; set; }
    [Required]
    public string PasswordString { get; set; }
    public string PostedRating { get; set; }
    }
}