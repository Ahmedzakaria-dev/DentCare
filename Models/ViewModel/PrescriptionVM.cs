using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class PrescriptionVM
    {
        public int PrescriptionId { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public DateTime PrescriptionDate { get; set; }

        public int MedicinesCount { get; set; }
    }
}
