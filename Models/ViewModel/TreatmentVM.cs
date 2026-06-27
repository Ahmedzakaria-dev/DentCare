using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class TreatmentVM
    {
        public int TreatmentId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ClinicName { get; set; }
    }
}
