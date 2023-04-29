using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using Tracker.ViewModels;
using Tracker.Data;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult AddSeedToBed(int id)
        {
            Bed theBed = context.Beds.Find(id);

            List<Seed> possibleSeeds = context.Seeds.ToList();

            AddSeedsToBedViewModel viewModel = new AddSeedsToBedViewModel(theBed, possibleSeeds);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddSeedToBed(AddSeedsToBedViewModel viewModel)
            {
            if (ModelState.IsValid)
            {
                int bedId = viewModel.BedId;
                int seedId = viewModel.SeedId;

                //is binding the seedId to the BedId from the viewModel
                //
                Bed theBed = context.Beds.Where(j => j.Id == bedId).First();

                Seed theSeed = context.Seeds.Where(s => s.Id == seedId).First();

                theBed.Seeds.Add(theSeed);

                context.SaveChanges();

                return Redirect("/Bed/Detail/" + bedId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            Seed theSeed = context.Seeds.Include(j=> j.Beds).Where(s =>s.Id == id).First();
            return View(theSeed);
        }
    }
}
