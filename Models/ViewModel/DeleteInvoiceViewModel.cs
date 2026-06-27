using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class DeleteInvoiceViewModel
    {
        public int InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }

        public decimal NetAmount { get; set; }
    }
}
