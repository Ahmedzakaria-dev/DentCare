using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppointmentTooth
    {
        public int AppointmentToothId { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public int ToothId { get; set; }

        public Tooth Tooth { get; set; }

        [StringLength(100)]
        public string? Notes { get; set; }
    }
}
