using Microsoft.AspNetCore.Mvc;

namespace WaterReminder.Controllers
{
    public class SeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
