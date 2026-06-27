using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(5)]
        public string? BloodType { get; set; }

        [StringLength(1000)]
        public string? MedicalHistory { get; set; }

        [StringLength(100)]
        public string? EmergencyContactName { get; set; }

        [Phone]
        public string? EmergencyContactPhone { get; set; }

        // Identity User

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // Navigation

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();

        public ICollection<MedicalRecord> MedicalRecords { get; set; }
            = new List<MedicalRecord>();

        public ICollection<Prescription> Prescriptions { get; set; }
            = new List<Prescription>();
    }
}
