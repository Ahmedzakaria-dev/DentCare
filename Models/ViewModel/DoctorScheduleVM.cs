using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class DoctorScheduleVM
    {
        public int DoctorScheduleId { get; set; }

        public string DoctorName { get; set; }

        public DayOfWeek Day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public bool IsAvailable { get; set; }

        public int MaxPatientsPerDay { get; set; }
    }
}
