using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tooth
    {
        public int ToothId { get; set; }

        [Range(1, 32)]
        public int ToothNumber { get; set; }

        public string? Name { get; set; }

        public ICollection<AppointmentTooth> AppointmentTeeth { get; set; }
            = new List<AppointmentTooth>();
    }
}
