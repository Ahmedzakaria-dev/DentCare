using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialization { get; set; }

        [Range(50, 10000)]
        public decimal ConsultationFee { get; set; }

        [StringLength(100)]
        public string? LicenseNumber { get; set; }

        [Range(0, 60)]
        public int ExperienceYears { get; set; }

        [StringLength(1000)]
        public string? Bio { get; set; }

        public bool IsAvailable { get; set; } = true;

        // User

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // Department

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        // Navigation

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();

        public ICollection<MedicalRecord> MedicalRecords { get; set; }
            = new List<MedicalRecord>();

        public ICollection<Prescription> Prescriptions { get; set; }
            = new List<Prescription>();

        public ICollection<DoctorSchedule> DoctorSchedules { get; set; }
            = new List<DoctorSchedule>();
    }
}
