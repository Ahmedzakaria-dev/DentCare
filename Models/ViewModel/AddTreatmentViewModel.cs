using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class AddTreatmentViewModel
    {
        [Required]
        [StringLength(150)]
        [Display(Name = "Treatment Name")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal Price { get; set; }

        [Required]
        public int ClinicId { get; set; }
    }
}
