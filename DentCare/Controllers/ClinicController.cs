using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class ClinicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
