using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Utility;

namespace DentCare.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClinicRepository _clinicRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly ITreatmentRepository _treatmentRepo;
        private readonly IReviewRepository _reviewRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(
            IClinicRepository clinicRepo,
            IDoctorRepository doctorRepo,
            IDepartmentRepository departmentRepo,
            ITreatmentRepository treatmentRepo,
            IReviewRepository reviewRepo,
            IAppointmentRepository appointmentRepo,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _clinicRepo = clinicRepo;
            _doctorRepo = doctorRepo;
            _departmentRepo = departmentRepo;
            _treatmentRepo = treatmentRepo;
            _reviewRepo = reviewRepo;
            _appointmentRepo = appointmentRepo;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(SD.Admin))
                {
                    return RedirectToAction("Index", "Clinic");
                }
                else if (User.IsInRole(SD.Doctor))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Doctor" });
                }
                else if (User.IsInRole(SD.Patient))
                {
                    return RedirectToAction("Index", "Appointment");
                }
            }

            ViewBag.ClinicsCount = _clinicRepo.GetAll(tracked: false).Count();
            ViewBag.DoctorsCount = _doctorRepo.GetAll(tracked: false).Count();
            ViewBag.DepartmentsCount = _departmentRepo.GetAll(tracked: false).Count();
            ViewBag.TreatmentsCount = _treatmentRepo.GetAll(tracked: false).Count();

            Expression<Func<Doctor, object>>[] doctorIncludes = { d => d.User, d => d.Department };
            var busyDoctorIds = _appointmentRepo.GetAll(tracked: false)
                .GroupBy(a => a.DoctorId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(3)
                .ToList();

            ViewBag.TopDoctors = _doctorRepo.GetAll(doctorIncludes, tracked: false)
                .Where(d => busyDoctorIds.Contains(d.DoctorId))
                .Take(3)
                .ToList();

            if (ViewBag.TopDoctors == null || ((List<Doctor>)ViewBag.TopDoctors).Count == 0)
            {
                ViewBag.TopDoctors = _doctorRepo.GetAll(doctorIncludes, tracked: false).Take(3).ToList();
            }

            Expression<Func<Review, object>>[] reviewIncludes = { r => r.Patient, r => r.Patient.User };
            ViewBag.LatestReviews = _reviewRepo.GetAll(reviewIncludes, tracked: false)
                .OrderByDescending(r => r.ReviewDate)
                .Take(3)
                .ToList();

            var busyClinicIds = _appointmentRepo.GetAll(tracked: false)
                .GroupBy(a => a.ClinicId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(3)
                .ToList();

            ViewBag.PopularClinics = _clinicRepo.GetAll(tracked: false)
                .Where(c => busyClinicIds.Contains(c.ClinicId))
                .Take(3)
                .ToList();

            if (ViewBag.PopularClinics == null || ((List<Clinic>)ViewBag.PopularClinics).Count == 0)
            {
                ViewBag.PopularClinics = _clinicRepo.GetAll(tracked: false).Take(3).ToList();
            }

            ViewBag.Services = _treatmentRepo.GetAll(tracked: false).Take(6).ToList();

            return View();
        }

        public IActionResult About()
        {
            ViewBag.ClinicsCount = _clinicRepo.GetAll(tracked: false).Count();
            ViewBag.DoctorsCount = _doctorRepo.GetAll(tracked: false).Count();
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Services()
        {
            var services = _treatmentRepo.GetAll(tracked: false).ToList();
            return View(services);
        }

        public IActionResult Doctors()
        {
            Expression<Func<Doctor, object>>[] doctorIncludes = { d => d.User, d => d.Department };
            var doctors = _doctorRepo.GetAll(doctorIncludes, tracked: false).ToList();
            return View(doctors);
        }
    }
}