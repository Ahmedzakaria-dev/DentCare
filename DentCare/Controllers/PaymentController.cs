using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
