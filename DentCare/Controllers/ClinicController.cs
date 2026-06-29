using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utility;

namespace DentCare.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class ClinicController : Controller
    {
        private readonly IClinicRepository _clinicRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IDoctorRepository _doctorRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private static readonly HashSet<string> _allowedExtensions = new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".webp"
        };

        private static readonly HashSet<string> _allowedMimeTypes = new(StringComparer.OrdinalIgnoreCase)
        {
            "image/jpeg", "image/png", "image/webp"
        };

        private const long _maxFileSize = 5 * 1024 * 1024;

        public ClinicController(
            IClinicRepository clinicRepo,
            IAppointmentRepository appointmentRepo,
            IDepartmentRepository departmentRepo,
            IDoctorRepository doctorRepo,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _clinicRepo = clinicRepo;
            _appointmentRepo = appointmentRepo;
            _departmentRepo = departmentRepo;
            _doctorRepo = doctorRepo;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int page = 1, int pageSize = 6)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize <= 0 ? 6 : pageSize;

            var clinics = _clinicRepo.GetAll(tracked: false).ToList();

            var busyClinicsIds = _appointmentRepo.GetAll(tracked: false)
                .GroupBy(a => a.ClinicId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(3)
                .ToList() ?? new List<int>();

            var totalClinics = clinics.Count;
            var totalPages = (int)Math.Ceiling((double)totalClinics / pageSize);

            var clinicsPaged = clinics
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.BusyClinicsIds = busyClinicsIds;

            return View(clinicsPaged);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0) return NotFound();

            var clinic = _clinicRepo.GetOne(expression: c => c.ClinicId == id, tracked: false);
            if (clinic == null)
            {
                TempData["error"] = "Clinic not found!";
                return RedirectToAction(nameof(Index));
            }

            Expression<Func<Appointment, object>>[] includeProps = {
                a => a.Doctor,
                a => a.Patient,
                a => a.Invoice
            };

            ViewBag.Appointments = _appointmentRepo.GetAll(includeProps, a => a.ClinicId == id, tracked: false);

            return View(clinic);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Clinic clinic, IFormFile? logoUrl)
        {
            if (logoUrl != null)
            {
                if (!ValidateUploadedImage(logoUrl, out string errorMessage))
                {
                    ModelState.AddModelError("Logo", errorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                if (logoUrl != null)
                {
                    clinic.Logo = await ProcessImageUploadAsync(logoUrl);
                }

                _clinicRepo.Add(clinic);
                TempData["success"] = "Clinic created successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(clinic);
        }

        public IActionResult Edit(int id)
        {
            if (id <= 0) return NotFound();

            var clinic = _clinicRepo.GetOne(expression: c => c.ClinicId == id, tracked: false);
            if (clinic == null)
            {
                TempData["error"] = "Clinic not found!";
                return RedirectToAction(nameof(Index));
            }

            return View(clinic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Clinic clinic, IFormFile? logoUrl)
        {
            var clinicDb = _clinicRepo.GetOne(expression: c => c.ClinicId == clinic.ClinicId, tracked: true);
            if (clinicDb == null)
            {
                TempData["error"] = "Clinic not found!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.Remove("Logo");

            if (logoUrl != null)
            {
                if (!ValidateUploadedImage(logoUrl, out string errorMessage))
                {
                    ModelState.AddModelError("Logo", errorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                if (logoUrl != null)
                {
                    DeletePhysicalImage(clinicDb.Logo);
                    clinicDb.Logo = await ProcessImageUploadAsync(logoUrl);
                }

                clinicDb.Name = clinic.Name;
                clinicDb.Address = clinic.Address;
                clinicDb.Phone = clinic.Phone;
                clinicDb.Email = clinic.Email;
                clinicDb.Description = clinic.Description;
                clinicDb.SubscriptionPlan = clinic.SubscriptionPlan;
                clinicDb.WorkingHours = clinic.WorkingHours;

                _clinicRepo.Commit();
                TempData["success"] = "Clinic updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(clinic);
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return NotFound();

            var clinic = _clinicRepo.GetOne([], c => c.ClinicId == id, tracked: false);
            if (clinic == null)
            {
                TempData["error"] = "Clinic not found!";
                return RedirectToAction(nameof(Index));
            }

            return View(clinic);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var clinic = _clinicRepo.GetOne([], c => c.ClinicId == id, tracked: true);
            if (clinic == null)
            {
                TempData["error"] = "Clinic not found!";
                return RedirectToAction(nameof(Index));
            }

            bool hasRelatedData = _appointmentRepo.GetAll(tracked: false).Any(a => a.ClinicId == id) ||
                                  _doctorRepo.GetAll([d => d.User], tracked: false).Any(d => d.User != null && d.User.ClinicId == id) ||
                                  _departmentRepo.GetAll(tracked: false).Any(d => d.ClinicId == id) ||
                                  _userManager.Users.Any(u => u.ClinicId == id);

            if (hasRelatedData)
            {
                TempData["error"] = "Cannot delete clinic! It contains related data or active users.";
                return RedirectToAction(nameof(Index));
            }

            DeletePhysicalImage(clinic.Logo);

            _clinicRepo.Delete(clinic);
            TempData["success"] = "Clinic deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        #region Helper Private Methods
        private bool ValidateUploadedImage(IFormFile file, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (file == null || file.Length == 0)
            {
                errorMessage = "Uploaded file is empty or missing.";
                return false;
            }

            if (file.Length > _maxFileSize)
            {
                errorMessage = "Image size cannot exceed 5 MB.";
                return false;
            }

            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!_allowedExtensions.Contains(extension) || !_allowedMimeTypes.Contains(file.ContentType))
            {
                errorMessage = "Security Warning: Invalid image format. Only JPG, JPEG, PNG, and WEBP are allowed.";
                return false;
            }

            return true;
        }

        private async Task<string> ProcessImageUploadAsync(IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            var extension = Path.GetExtension(file.FileName).ToLower();
            var fileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(wwwRootPath, @"images\clinics");

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            await using var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }

        private void DeletePhysicalImage(string? logoFileName)
        {
            if (!string.IsNullOrEmpty(logoFileName))
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    var oldFilePath = Path.Combine(wwwRootPath, @"images\clinics", logoFileName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion
    }
}