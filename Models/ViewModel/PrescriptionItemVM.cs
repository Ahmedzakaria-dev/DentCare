using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class PrescriptionItemVM
    {
        public int PrescriptionItemId { get; set; }

        public string MedicineName { get; set; }

        public string Dosage { get; set; }

        public string Instructions { get; set; }

        public string? Duration { get; set; }

        public int Quantity { get; set; }
    }
}
