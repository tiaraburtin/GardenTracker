using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Tracker.Data;
using Tracker.Models;
using Tracker.ViewModels;

namespace Tracker.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult Add()
        {
            Seed seed = new Seed();
            return View(seed);
        }

        [HttpPost]
        public IActionResult AddSeed(Seed seed)
        {
            if (ModelState.IsValid)
            {
                context.Seeds.Add(seed);
                context.SaveChanges();

                return Redirect("/Seed/");
            }

            return View("Add", seed);
        }

        [HttpGet]
        public IActionResult AddSeedToBedForm(int id)
        {
            Bed theBed = context.Beds.Find(id);

            List<Seed> possibleSeeds = context.Seeds.ToList();

            AddSeedViewModel viewModel = new AddSeedViewModel(theBed, possibleSeeds);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddSeedToBed(AddSeedViewModel addSeedViewModel)
            {
            if (ModelState.IsValid)
            {
                int bedId = addSeedViewModel.BedId;
                int seedId = addSeedViewModel.SeedId;

                Bed theBed = context.Beds.Include(s => s.Seeds).Where(j => j.Id == bedId).First();
                Seed theSeed = context.Seeds.Where(s => s.Id == seedId).First();

                theBed.Seeds.Add(theSeed);

                context.SaveChanges();

                return Redirect("/Seed/Detail/" + bedId);
            }

            return View(addSeedViewModel);
        }
    }
}
