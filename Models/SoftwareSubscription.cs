using System;
using System.ComponentModel.DataAnnotations;

namespace SoftwareSubscriptionApp.Models
{
    public class SoftwareSubscription
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Software Name")]
        public string SoftwareName { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Display(Name="Plan Type")]
        public string PlanType { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Amount { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name="Email Subscribed With")]
        public string EmailSubscribed { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Subscribed Date")]
        public DateTime SubscribedDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Renewal Date")]
        public DateTime RenewalDate { get; set; }
    }
}
