using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class TreatmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
