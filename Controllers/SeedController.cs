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


        public SeedController(TrackerDbContext dbContext) 
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
        public IActionResult AddSeed(AddSeedViewModel addSeedViewModel)
        {
            if (ModelState.IsValid)
            {
                Seed newSeed = new Seed
                {
                    Name = addSeedViewModel.Name,
                };

                context.Seeds.Add(newSeed);
                context.SaveChanges();

                return Redirect("/Seed/");
            }

            return View("Add", addSeedViewModel);
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

        [HttpPost]
        public IActionResult gatherSeeds(int[] editIds)
        {
            List<Seed> seedsToEdit = new List<Seed>();
            foreach (int seedId in editIds)
            {
                Seed theSeed = context.Seeds.Find(seedId);
                seedsToEdit.Add(theSeed);

                context.SaveChanges();

            }
            return View("EditSeed", seedsToEdit);
        }

        [HttpPost]
        public IActionResult EditSeedSubmit(int[] seedIds, string[] seeds, int[]hardinessZone, DateTime[] dateplanted)
        {

            for (int i = 0; i < seedIds.Length; i++)
            {
                Seed seed = context.Seeds.Find(seedIds[i]);
                seed.Name = seeds[i];
                seed.HardinessZone = seeds[i];
                seed.DatePlanted = dateplanted[i];
                
            }

            context.SaveChanges();

            return Redirect("Index");
        }
        public IActionResult Delete()
        {
            ViewBag.seeds = context.Seeds.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult DeleteSeed(int[] deleteIds)
        {
            foreach (int seedId in deleteIds)
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
