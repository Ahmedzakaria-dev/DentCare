using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(500)]
        public string Diagnosis { get; set; }

        [StringLength(1000)]
        public string? TreatmentPlan { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        // Appointment

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        // Doctor

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        // Patient

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        // Navigation

        public ICollection<Prescription> Prescriptions { get; set; }
            = new List<Prescription>();
    }
}
