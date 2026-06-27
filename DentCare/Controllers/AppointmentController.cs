using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
