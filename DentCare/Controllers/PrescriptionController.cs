using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class PrescriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
