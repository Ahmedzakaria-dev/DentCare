using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class DepartmentVM
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string ClinicName { get; set; }

        public int DoctorsCount { get; set; }
    }
}
