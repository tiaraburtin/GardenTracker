using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Tracker.Models;
//using Microsoft.Software.Form;


namespace Tracker.Controllers
{
    public class WaterController : Controller
    {


        public IActionResult Index()
        {  
            
            List<Seed> seed = new List<Seed>();
            for (int i = 0; i < seed.Count; i++)
            {
                Seed theSeed = seed[i];

                //if (theSeed.NeedsWater.Equals(DateTime.Now))
                //    (
                //    //MessageBox.Show("Water Reminder" + "Time To Water Your" seed[i].Name)
                //   );
            }

            return View("AddSeedToBed");
        }
    }
}

