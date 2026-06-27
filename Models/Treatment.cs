using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Treatment
    {
        public int TreatmentId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        // Clinic

        public int ClinicId { get; set; }

        public Clinic Clinic { get; set; }

        // Navigation

        public ICollection<AppointmentTreatment> AppointmentTreatments { get; set; }
            = new List<AppointmentTreatment>();
    }
}
