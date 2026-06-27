using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AddDoctorViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string? Address { get; set; }

        public string? ProfileImage { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public decimal ConsultationFee { get; set; }

        public string? LicenseNumber { get; set; }

        public int ExperienceYears { get; set; }

        public string? Bio { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
