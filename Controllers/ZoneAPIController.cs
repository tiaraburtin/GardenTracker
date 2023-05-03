using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;

namespace Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetZone(string zipCode)
        {
            return View();
        }
     }
    
}


