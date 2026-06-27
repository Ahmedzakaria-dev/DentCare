using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AddPrescriptionItemViewModel
    {
        [Required]
        public int PrescriptionId { get; set; }

        [Required]
        public string MedicineName { get; set; }

        [Required]
        public string Dosage { get; set; }

        [Required]
        public string Instructions { get; set; }

        public string? Duration { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
