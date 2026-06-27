using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class ClinicVM
    {
        public int ClinicId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string SubscriptionPlan { get; set; }

        public int DepartmentsCount { get; set; }

        public int DoctorsCount { get; set; }

        public int PatientsCount { get; set; }
    }
}
