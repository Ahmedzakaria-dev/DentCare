using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository.IRepository;
using Utility;
using Models;
using System.Linq.Expressions;

namespace DentCare.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class DashboardController : Controller
    {
        private readonly IClinicRepository _clinicRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly INotificationRepository _notificationRepo;
        private readonly IPatientRepository _patientRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly ITreatmentRepository _treatmentRepo;

        public DashboardController(
            IClinicRepository clinicRepo,
            IDoctorRepository doctorRepo,
            IAppointmentRepository appointmentRepo,
            IInvoiceRepository invoiceRepo,
            INotificationRepository notificationRepo,
            IPatientRepository patientRepo,
            IDepartmentRepository departmentRepo,
            ITreatmentRepository treatmentRepo)
        {
            _clinicRepo = clinicRepo;
            _doctorRepo = doctorRepo;
            _appointmentRepo = appointmentRepo;
            _invoiceRepo = invoiceRepo;
            _notificationRepo = notificationRepo;
            _patientRepo = patientRepo;
            _departmentRepo = departmentRepo;
            _treatmentRepo = treatmentRepo;
        }

        public IActionResult Index()
        {
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);

            ViewBag.ClinicsCount = _clinicRepo.GetAll(tracked: false).Count();
            ViewBag.PatientsCount = _patientRepo.GetAll(tracked: false).Count();
            ViewBag.DepartmentsCount = _departmentRepo.GetAll(tracked: false).Count();
            ViewBag.TreatmentsCount = _treatmentRepo.GetAll(tracked: false).Count();

            var doctors = _doctorRepo.GetAll(includeProp: new Expression<Func<Doctor, object>>[] { d => d.User }, tracked: false).ToList();
            ViewBag.DoctorsCount = doctors.Count;
            ViewBag.LatestDoctors = doctors.OrderByDescending(d => d.DoctorId).Take(5).ToList();

            var appointments = _appointmentRepo.GetAll(
                includeProp: new Expression<Func<Appointment, object>>[] { a => a.Doctor.User, a => a.Patient.User, a => a.Clinic },
                tracked: false).ToList();

            ViewBag.AppointmentsCount = appointments.Count;
            ViewBag.TodayAppointmentsCount = appointments.Count(a => a.AppointmentDate.Date == today);
            ViewBag.CancelledAppointmentsCount = appointments.Count(a => a.Status == "Cancelled");

            ViewBag.UpcomingAppointments = appointments
                .Where(a => a.AppointmentDate >= today && a.Status != "Cancelled")
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.AppointmentTime)
                .Take(5).ToList();

            var invoices = _invoiceRepo.GetAll(tracked: false).ToList();
            ViewBag.TotalRevenue = invoices.Where(i => i.IsPaid).Sum(i => i.NetAmount);
            ViewBag.RevenueToday = invoices.Where(i => i.IsPaid && i.InvoiceDate.Date == today).Sum(i => i.NetAmount);
            ViewBag.RevenueThisMonth = invoices.Where(i => i.IsPaid && i.InvoiceDate >= startOfMonth).Sum(i => i.NetAmount);

            ViewBag.UnpaidInvoicesCount = invoices.Count(i => !i.IsPaid);
            ViewBag.PaidInvoicesCount = invoices.Count(i => i.IsPaid);

            ViewBag.LatestPatients = _patientRepo.GetAll(includeProp: new Expression<Func<Patient, object>>[] { p => p.User }, tracked: false)
                .OrderByDescending(p => p.PatientId).Take(5).ToList();

            ViewBag.LatestNotifications = _notificationRepo.GetAll(tracked: false)
                .OrderByDescending(n => n.NotificationId).Take(5).ToList();

            var monthlyAppointments = appointments
                .Where(a => a.AppointmentDate.Year == today.Year)
                .GroupBy(a => a.AppointmentDate.Month)
                .Select(g => new { Month = g.Key, Count = g.Count() })
                .ToDictionary(k => k.Month, v => v.Count);

            var appointmentMonthsData = new int[12];
            for (int i = 1; i <= 12; i++)
            {
                appointmentMonthsData[i - 1] = monthlyAppointments.ContainsKey(i) ? monthlyAppointments[i] : 0;
            }
            ViewBag.ChartAppointmentMonths = appointmentMonthsData;

            ViewBag.ChartConfirmedCount = appointments.Count(a => a.Status == "Confirmed");
            ViewBag.ChartPendingCount = appointments.Count(a => a.Status == "Pending");
            ViewBag.ChartCancelledCount = appointments.Count(a => a.Status == "Cancelled");

            var monthlyRevenue = invoices
                .Where(i => i.IsPaid && i.InvoiceDate.Year == today.Year)
                .GroupBy(i => i.InvoiceDate.Month)
                .Select(g => new { Month = g.Key, Amount = g.Sum(i => i.NetAmount) })
                .ToDictionary(k => k.Month, v => v.Amount);

            var revenueMonthsData = new decimal[12];
            for (int i = 1; i <= 12; i++)
            {
                revenueMonthsData[i - 1] = monthlyRevenue.ContainsKey(i) ? monthlyRevenue[i] : 0;
            }
            ViewBag.ChartRevenueMonths = revenueMonthsData;

            return View();
        }
    }
}