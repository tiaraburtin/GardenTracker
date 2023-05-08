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
		   .Include(j => j.Waters
		   .FirstOrDefault(j =>j.Id == id);

            WaterSeedDetailViewModel viewModel = new WaterSeedDetailViewModel(theSeed);

			return View(viewModel);

		
        }
    }
}
