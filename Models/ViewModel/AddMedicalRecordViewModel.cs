using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AddMedicalRecordViewModel
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public string Diagnosis { get; set; }

        public string? TreatmentPlan { get; set; }

        public string? Notes { get; set; }
    }
}
