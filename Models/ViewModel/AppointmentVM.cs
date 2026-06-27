using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AppointmentVM
    {
        public int AppointmentId { get; set; }

        public string DoctorName { get; set; }

        public string PatientName { get; set; }

        public string ClinicName { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string Status { get; set; }

        public string? ReasonForVisit { get; set; }
    }
}
