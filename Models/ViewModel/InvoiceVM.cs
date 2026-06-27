using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class InvoiceVM
    {
        public int InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Discount { get; set; }

        public decimal NetAmount { get; set; }

        public bool IsPaid { get; set; }

        public DateTime InvoiceDate { get; set; }
    }
}
