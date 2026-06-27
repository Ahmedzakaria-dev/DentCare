using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        // Foreign Key

        public int ClinicId { get; set; }

        public Clinic Clinic { get; set; }

        // Navigation

        public ICollection<Doctor> Doctors { get; set; }
            = new List<Doctor>();
    }
}
