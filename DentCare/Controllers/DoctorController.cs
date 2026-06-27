using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
