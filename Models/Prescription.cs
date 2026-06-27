using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        public DateTime PrescriptionDate { get; set; } = DateTime.Now;

        public string? Notes { get; set; }

        // Medical Record

        public int MedicalRecordId { get; set; }

        public MedicalRecord MedicalRecord { get; set; }

        // Doctor

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        // Patient

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        // Navigation

        public ICollection<PrescriptionItem> PrescriptionItems { get; set; }
            = new List<PrescriptionItem>();
    }
}
