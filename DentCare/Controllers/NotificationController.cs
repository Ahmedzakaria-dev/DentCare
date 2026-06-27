using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
