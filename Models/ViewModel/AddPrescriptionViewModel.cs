using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AddPrescriptionViewModel
    {
        [Required]
        public int MedicalRecordId { get; set; }

        public string? Notes { get; set; }
    }
}
