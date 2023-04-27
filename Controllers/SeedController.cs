using Microsoft.AspNetCore.Mvc;
using Tracker.Data;
using Tracker.Models;
using Tracker.ViewModels;

namespace Tracker.Controllers
{
    public class SeedController : Controller
    {
        private TrackerDbContext context;

        public SeedController(TrackerDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Seed> seeds = context.Seeds.ToList();
            return View(seeds);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            //this finds the garden bed from the database
            Bed theBed = context.Beds.Find(id);
            List<Seed> possibleSeeds = context.Seeds.ToList();

            AddSeedViewModel addSeedViewModel = new AddSeedViewModel(theBed, possibleSeeds);
            return View(addSeedViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddSeedForm(AddSeedViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Bed theBed = context.Beds.Find(viewModel.BedId);
                Seed newSeed = new Seed
                {
                    Name = viewModel.Name,
                    HardiZone = viewModel.HardiZone,
                    WaterSchedule = viewModel.WaterSchedule,
                    //BedId = theBed,
                };

                context.Beds.Add(newSeed);
                context.SaveChanges();

                return Redirect("/Seed");
            }
            else
            {
                return View("Create", viewModel);
            }
        }
    }
}
