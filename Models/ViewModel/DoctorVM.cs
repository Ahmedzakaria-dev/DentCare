using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class DoctorVM
    {
        public int DoctorId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Specialization { get; set; }

        public decimal ConsultationFee { get; set; }

        public int ExperienceYears { get; set; }

        public string DepartmentName { get; set; }

        public bool IsAvailable { get; set; }
    }

}
