using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class MedicalRecordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
