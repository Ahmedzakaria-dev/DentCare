using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class DashboardVM
    {
        public int TotalDoctors { get; set; }

        public int TotalPatients { get; set; }

        public int TotalAppointments { get; set; }

        public int TodayAppointments { get; set; }

        public int CompletedAppointments { get; set; }

        public int CancelledAppointments { get; set; }

        public decimal TodayRevenue { get; set; }

        public decimal MonthlyRevenue { get; set; }

        public int TotalTreatments { get; set; }

        public int PendingInvoices { get; set; }

        public int PaidInvoices { get; set; }
    }
}
