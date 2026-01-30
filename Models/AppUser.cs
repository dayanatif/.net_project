using System.ComponentModel.DataAnnotations;

namespace SoftwareSubscriptionApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User"; // "Admin" or "User"
    }

    public static class AppRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
