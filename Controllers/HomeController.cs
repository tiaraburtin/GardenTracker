using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Tracker.Data;
using Tracker.Models;

namespace Home.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<IdentityUser> UserManager;
        private TrackerDbContext context;

        public HomeController(TrackerDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
            context = dbContext;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            List<string> messages = new List<string>();
            List<string> errors = new List<string>();
            List<Seed> seeds = context.Seeds.ToList();
            foreach (var seedz in seeds)
            {
                if (seedz == null)
                {
                    continue;
                }
                TimeSpan diffBetwnDatePlanted_TimeNow = DateTime.Today - seedz.DatePlanted;
                
                if (diffBetwnDatePlanted_TimeNow.Days >= float.Parse(seedz.WaterSchedule))
                {
                    double daysOverDue = Math.Abs(double.Parse(seedz.WaterSchedule) - diffBetwnDatePlanted_TimeNow.Days);
                    errors.Add( seedz.Name + " is: " + daysOverDue + " days overdue for watering " );
                }
                else
                {
                    int daysTillWater = int.Parse(seedz.WaterSchedule) - diffBetwnDatePlanted_TimeNow.Days;
                    messages.Add("Days until next watering for " + seedz.Name + " is: " + daysTillWater) ;
                }
            }
            ViewBag.messages = messages;
            ViewBag.errors = errors;
            return View();
        }
    }
}
