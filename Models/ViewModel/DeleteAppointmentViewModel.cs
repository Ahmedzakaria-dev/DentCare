using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class DeleteAppointmentViewModel
    {
        public int AppointmentId { get; set; }

        public string DoctorName { get; set; }

        public string PatientName { get; set; }

        public DateTime AppointmentDateTime { get; set; }
    }
}
