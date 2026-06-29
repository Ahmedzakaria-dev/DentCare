using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? ClinicId { get; set; }
        public Clinic? Clinic { get; set; }

        public Doctor? Doctor { get; set; }

        public Patient? Patient { get; set; }

        public ICollection<Notification> Notifications { get; set; }
            = new List<Notification>();
    }
}
