using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; } = "Pending";

        [StringLength(500)]
        public string? ReasonForVisit { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Clinic

        public int ClinicId { get; set; }

        public Clinic Clinic { get; set; }

        // Doctor

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        // Patient

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        // Navigation

        public MedicalRecord? MedicalRecord { get; set; }

        public Invoice? Invoice { get; set; }
    }
}
