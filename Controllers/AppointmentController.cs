using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
