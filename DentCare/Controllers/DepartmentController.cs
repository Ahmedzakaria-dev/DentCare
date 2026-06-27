using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
