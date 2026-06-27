using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class MedicalRecordVM
    {
        public int MedicalRecordId { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public DateTime VisitDate { get; set; }

        public string Diagnosis { get; set; }

        public string? TreatmentPlan { get; set; }
    }
}
