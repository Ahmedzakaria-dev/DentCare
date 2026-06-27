using Microsoft.AspNetCore.Mvc;

namespace DentCare.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
