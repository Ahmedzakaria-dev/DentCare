using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
