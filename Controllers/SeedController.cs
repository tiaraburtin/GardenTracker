﻿using System;
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
        private readonly ILogger<SeedController> _logger;

        public SeedController(TrackerDbContext dbContext, ILogger<SeedController> logger)
        {
            context = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

        [HttpGet]
        public IActionResult AddSeedToBed(int id)
        {
            Bed theBed = context.Beds.Find(id);

            List<Seed> possibleSeeds = context.Seeds.ToList();

            AddSeedViewModel viewModel = new AddSeedViewModel(theBed, possibleSeeds);
            return View(viewModel);
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
                Bed theBed = context.Beds.Where(j => j.Id == bedId).First();

                Seed theSeed = context.Seeds.Where(s => s.Id == seedId).First();

                theBed.Seeds.Add(theSeed);

                context.SaveChanges();

                return Redirect("/Bed/Detail/" + bedId);
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
            _logger.LogInformation($"Detail method called with id = {id}");

			Seed theSeed = context.Seeds
		   .Include(j => j.Beds)
		   .FirstOrDefault(j =>j.Id == id);

            SeedDetailViewModel viewModel = new SeedDetailViewModel(theSeed);

			return View(viewModel);

		
        }
    }
}
