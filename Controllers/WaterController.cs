using Microsoft.AspNetCore.Mvc;
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

            return View("../Seed/Index"); // TODO: Fix
        }

        public IActionResult Add()
        {
            Water water = new Water();
            return View("../Seed/Index"); // TODO: Fix
        }

        [HttpGet]
        public IActionResult AddWaterSeedToBed(int id)
        {
            Bed theBed = Context.Beds.Find(id);
            List<Water> possibleWaters = Context.Waters.ToList();

            AddWaterSeedToBedViewModel viewModel = new AddWaterSeedToBedViewModel(theBed, possibleWaters);

            return View("../Seed/Index"); // TODO: Fix
        }

        [HttpPost]
        public IActionResult Add(Water water)
        {
            if (ModelState.IsValid)
            {
                Context.Waters.Add(water);

                Context.SaveChanges();
                return Redirect("Bed/Detail");
            }

            return View("../Seed/AddSeedToWater", new AddWaterSeedToBedViewModel());  // TODO: Fix
        }


        [HttpPost]
        public IActionResult AddWaterSeedToBed(AddWaterSeedToBedViewModel viewModel)
        {
            //this is unfinished, im confused on how to connect seed and bed to the water id
            if (ModelState.IsValid)
            {
        
        
                int bedId = viewModel.BedId;

                Bed theBed = Context.Beds.First(t => t.Id == bedId);
                Seed selectedSeed = Context.Seeds.First(a => a.Id == viewModel.SeedId);

                // Add water
                Context.Waters.Add(new Water
                {
                    Bedname = theBed.Name,
                    DatePlanted = viewModel.DatePlanted,
                    Seedname = selectedSeed.Name
                });
                Context.SaveChanges();

                // Add seed water bed
                Water water = Context.Waters.OrderByDescending(a => a.Id).First();
        
                theBed.SeedWaterBed.Add(new SeedWaterBed
                {
                    BedId = theBed.Id,
                    SeedId = selectedSeed.Id,
                    WaterId = water.Id
                });


                if (water.ConvertWaterToTime())
                {
                    ViewBag.NeedsWaterAlert = true;
                }


                Context.SaveChanges();
                return Redirect("~/Bed/Detail/" + bedId);
        
            }

            return View("../Seed/AddSeedToWater");
        
        }
    }
}