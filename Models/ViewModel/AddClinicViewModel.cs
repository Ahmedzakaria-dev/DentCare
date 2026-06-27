using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel
{
    public class AddClinicViewModel
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        [Display(Name = "Clinic Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Clinic Address")]
        public string Address { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Description { get; set; }

        public string? Logo { get; set; }

        [Required]
        public string SubscriptionPlan { get; set; }

        public string? WorkingHours { get; set; }
    }
}
