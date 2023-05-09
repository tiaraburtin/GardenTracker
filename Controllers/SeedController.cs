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

namespace Tracker.Controllers
{
    public class SeedController : Controller
    {
        private TrackerDbContext context;
       

        public SeedController(TrackerDbContext dbContext, ILogger<SeedController> logger)
        {
            context = dbContext;
       
        }


        public IActionResult Index()
        {
			List<Seed> seeds = context.Seeds.ToList();
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
        public IActionResult Add(AddSeedViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Seed newSeed = new Seed
                {
                    Name = viewModel.Name,
                    WaterSchedule = viewModel.WaterSchedule,
                    HardinessZone = viewModel.HardinessZone
                };

                context.Seeds.Add(newSeed);
                context.SaveChanges();

                return Redirect("/Seed/");
            }

            return View("Add", viewModel);
        }

        [HttpGet]
        public IActionResult AddWater(int id)
        {
            Water? theWater = context.Waters.Find(id);
            List<Seed>? possibleSeeds = context.Seeds.ToList();

            AddWaterSeedToBedViewModel viewModel = new AddWaterSeedToBedViewModel(theWater, possibleSeeds);

            return View("AddSeedToWater", viewModel);
        }

        [HttpPost]
        public IActionResult AddWater(AddWaterSeedToBedViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int waterId = viewModel.WaterId;
                int seedId = viewModel.SeedId;

                Water theWater = context.Waters.Include(p => p.Seeds).Where(e => e.Id == waterId).First();
                Seed theSeed = context.Seeds.Where(s => s.Id == seedId).First();

                theWater.Seeds.Add(theSeed);
                context.SaveChanges();
                return Redirect("Bed/Detail" + waterId);
            }
            return View(viewModel);
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
           .Include(j => j.Waters)
           .Where(j => j.Id == id).First();

            //SeedDetailViewModel viewModel = new SeedDetailViewModel(theSeed);

			return View(theSeed);

		
        }
    }
}
