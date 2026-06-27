using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }

        [Required]
        [StringLength(200)]
        public string MedicineName { get; set; }

        [Required]
        [StringLength(100)]
        public string Dosage { get; set; }

        [Required]
        [StringLength(500)]
        public string Instructions { get; set; }

        [StringLength(100)]
        public string? Duration { get; set; }

        public int Quantity { get; set; } = 1;

        // Foreign Key

        public int PrescriptionId { get; set; }

        public Prescription Prescription { get; set; }
    }
}
