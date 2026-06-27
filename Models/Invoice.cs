using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public decimal Discount { get; set; }

        public decimal NetAmount { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public bool IsPaid { get; set; }

        // Appointment

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        // Navigation

        public Payment? Payment { get; set; }
    }
}
