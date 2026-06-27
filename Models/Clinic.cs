using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Clinic
    {
        public int ClinicId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Logo { get; set; }

        public string? Description { get; set; }

        public string SubscriptionPlan { get; set; }

        public string? WorkingHours { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties

        public ICollection<ApplicationUser> Users { get; set; }
            = new List<ApplicationUser>();

        public ICollection<Department> Departments { get; set; }
            = new List<Department>();

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();
    }
}
