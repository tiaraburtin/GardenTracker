using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Tracker.Data;
using Tracker.Models;
using Tracker.ViewModels;
//using Microsoft.Software.Form;


namespace Tracker.Controllers
{
    public class WaterController : Controller
    {

        private TrackerDbContext Context;

        public WaterController(TrackerDbContext context)
        {
            Context = context;
        }


        public IActionResult Index()
        {

            List<Water> water = Context.Waters.ToList();
            //for (int i = 0; i < water.Count; i++)
            //{
            //    Seed theSeed = seed[i];

            //    if (theSeed.NeedsWater.Equals(DateTime.Now))
            //    {
            //        //put this i a viewbag and add message: DO THIS IN THE DOM IN JAVASCRIPT
            //    };
            //}

            return View(water);
        }

        public IActionResult Add()
        {
            Water water = new Water();
            return View(water);

        }

        [HttpGet]
        public IActionResult AddWaterSeedToBed(int id)
        { 

            Bed theBed = Context.Beds.Find(id);
            List<Water> possibleWaters = Context.Waters.ToList();

            AddWaterSeedToBedViewModel viewModel = new AddWaterSeedToBedViewModel(theBed, possibleWaters);

            return View(viewModel);
            }

        [HttpPost]
        public IActionResult Add(Water water)
        {

            if (ModelState.IsValid)
            {

                Context.Waters.Add(water);
                if (water.ConvertWaterToTime() == DateTime.Now)
                {
                    ViewBag.NeedsWaterAlert = "Its Time To Water Your Plant";
                }
                Context.SaveChanges();
                return Redirect("Bed/Detail");
            }
            return View("Seed/AddSeedToWater", water);
        } 


        [HttpPost]
        public IActionResult AddWaterSeedToBed(AddWaterSeedToBedViewModel viewModel)
        {
            //this is unfinished, im confused on how to connect seed and bed to the water id
            if (ModelState.IsValid)
            {


                int bedId = viewModel.BedId;
                int waterId = viewModel.WaterId;


                Bed theBed = Context.Beds.Include(p => p.Waters).Where(t => t.Id == bedId).First();
                Water theWater = Context.Waters.Where(t => t.Id == waterId).First();

                theBed.Waters.Add(theWater);
                Context.SaveChanges();
                return Redirect("Bed/Detail" + bedId);

            }
            return View(viewModel);

        }

    }

}

