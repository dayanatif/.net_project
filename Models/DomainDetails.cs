using System;
using System.ComponentModel.DataAnnotations;

namespace SoftwareSubscriptionApp.Models
{
    public class DomainDetails
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Domain Name")]
        public string DomainName { get; set; }

        [Required]
        [Display(Name="Domain Registrar")]
        public string DomainRegistrar { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Domain Registered Date")]
        public DateTime RegisteredDate { get; set; }

        [Required]
        [Display(Name="Auto Renew")]
        public bool AutoRenew { get; set; }  

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Renewal Date")]
        public DateTime RenewalDate { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Amount { get; set; }

        [Display(Name="Domain Nameserver 1")]
        public string DomainNameserver1 { get; set; } 

        [Display(Name="Domain Nameserver 2")]
        public string DomainNameserver2 { get; set; }
    }
}
