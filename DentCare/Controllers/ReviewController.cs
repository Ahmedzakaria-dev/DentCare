using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
