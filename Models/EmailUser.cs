using System;
using System.ComponentModel.DataAnnotations;

namespace SoftwareSubscriptionApp.Models
{
    public class EmailUser
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string Email { get; set; }

        [Display(Name="Company")]
        public string Company { get; set; }

        [Display(Name="Storage (GB)")]
        [Range(0, 10000)]
        public int StorageGB { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
