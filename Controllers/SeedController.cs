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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Tracker.Controllers
{
    [Authorize]
    public class SeedController : Controller
    {
        private UserManager<IdentityUser> UserManager;

        private TrackerDbContext context;


        public SeedController(TrackerDbContext dbContext, ILogger<SeedController> logger, UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
            context = dbContext;

        }


        public IActionResult Index()
        {
            string id = UserManager.GetUserId(User);
            List<Seed> seeds = context.Seeds.Where(b=> b.UserId == id).ToList();
            //List<Seed> seeds = context.Seeds.ToList();
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
                Seed newSeed = new Seed
                {
                    Name = seed.Name,
                    DatePlanted = seed.DatePlanted,
                    HardinessZone = seed.HardinessZone,
                    UserId = seed.UserId,
                    Id = seed.Id

                };
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

            AddSeedViewModel addSeedViewModel = new AddSeedViewModel(theBed, possibleSeeds);
            return View(addSeedViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddSeedToBed(AddSeedViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int bedId = viewModel.BedId;
                int seedId = viewModel.SeedId;

                //is binding the seedId to the BedId from the viewModel
                //
                Seed theSeed = context.Seeds.Include(b => b.Beds).Where(s => s.Id == seedId).First();
                Bed theBed = context.Beds.Where(j => j.Id == bedId).First();



                theBed.Seeds.Add(theSeed);

                context.SaveChanges();

                return Redirect("/Bed/Detail/" + bedId);
            }
            return View("AddSeedToBed", viewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.seeds = context.Seeds.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult DeleteSeed(int[] seedIds)
        {
            foreach (int seedId in seedIds)
            {
                Seed theSeed = context.Seeds.Find(seedId);
                context.Seeds.Remove(theSeed);
            }

            context.SaveChanges();

            return Redirect("/Seed");
        }


        public IActionResult Detail(int id)
        {

            Seed theSeed = context.Seeds
           .Include(j => j.Beds)
           .FirstOrDefault(j => j.Id == id);

            SeedDetailViewModel viewModel = new SeedDetailViewModel(theSeed);

            return View(viewModel);


        }
    }
}
