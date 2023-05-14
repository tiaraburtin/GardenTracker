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
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Tracker.Controllers
{
    public class BedController : Controller
    {
        private TrackerDbContext context;

        public BedController(TrackerDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Bed> beds = context.Beds.ToList();
            return View(beds);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddBedViewModel bed = new AddBedViewModel();
            return View(bed);
        }

        [HttpPost]
        public IActionResult AddBed(AddBedViewModel viewModel)
        {
            if (ModelState.IsValid)
                    {
                Bed newBed = new Bed
                {
                    Name = viewModel.Name,
                    //IsItTime = viewModel.IsItTime

                };
                    

                context.Beds.Add(newBed);
                      
                context.SaveChanges();

                return Redirect("/Bed/");
            }
            return View("Add", viewModel);
        }

        //[HttpGet]
        //public IActionResult AddBedToWater(int id)
        //{
        //    Water theWater = context.Waters.Find(id);

        //    List<Bed> possibleBeds = context.Beds.ToList();

        //    AddBedViewModel viewModel = new AddBedViewModel(theWater, possibleBeds);
        //    return View(viewModel);
        //}

        //[HttpPost]
        //public IActionResult ProcessAddBedToSeed(AddBedViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int bedId = viewModel.BedId;
        //        int seedId = viewModel.SeedId;

        //        //access seeds property in bed table and look for bedId that matches the one selected
        //        //access seeds table and selected seed
        //        //if seed already has a relationship with bed it won't be found and won't be added
        //        Bed theBed = context.Beds.Include(b=>b.Seeds).Where(b => b.Id == bedId).First();
        //        Seed theSeed = context.Seeds.Where(s => s.Id == seedId).First();


        //            theSeed.Beds.Add(theBed);

        //            context.SaveChanges();



        //        return Redirect("/Seed/Detail/" + seedId);
        //    }
        //    return View(viewModel);

        //}
        public IActionResult Delete()
        {
            ViewBag.beds = context.Beds.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult DeleteBed(int[] bedIds)
        {
            foreach (int bedId in bedIds)
            {
                Bed theBed = context.Beds.Find(bedId);
                context.Beds.Remove(theBed);
            }

            context.SaveChanges();

            return Redirect("/Bed");
        }

        public IActionResult Detail(int id)
        {
            Bed theBed = context.Beds
            .Include(j => j.SeedWaterBed).ThenInclude(a => a.Seed)
            .Include(j => j.SeedWaterBed).ThenInclude(a => a.Water)
            .Single(j => j.Id == id);


            //Load THE SEEDS on the view model

            BedDetailViewModel viewModel = new BedDetailViewModel(theBed);

            return View(viewModel);
        }
    }
}
      

