using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppointmentTreatment
    {
        public int AppointmentTreatmentId { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; }

        [Range(1, 50)]
        public int Quantity { get; set; } = 1;

        public decimal Price { get; set; }

        public string? Notes { get; set; }
    }
}
