using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AddDepartmentViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int ClinicId { get; set; }
    }
}
