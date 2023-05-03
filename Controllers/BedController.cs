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
            Bed bed = new Bed();
            return View();
        }

        [HttpPost]
        public IActionResult AddBed(Bed bed)
        {
            if (ModelState.IsValid)
            {
                context.Beds.Add(bed);
                context.SaveChanges();

                return Redirect("/Bed/");
            }
            return View("Add", bed);
        }

        [HttpGet]
        public IActionResult AddBedToSeed(int id)
        {
            Seed theSeed = context.Seeds.Find(id);

            List<Bed> possibleBeds = context.Beds.ToList();

            AddBedViewModel viewModel = new AddBedViewModel(theSeed, possibleBeds);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddBedToSeed(AddBedViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int bedId = viewModel.BedId;
                int seedId = viewModel.SeedId;

                //access seeds property in bed table and look for bedId that matches the one selected
                //access seeds table and selected seed
                //if seed already has a relationship with bed it won't be found and won't be added
                Bed theBed = context.Beds.Include(b => b.Seeds).Where(b => b.Id == bedId).First();
                Seed theSeed = context.Seeds.Where(s => s.Id == seedId).First();


                theSeed.Beds.Add(theBed);

                context.SaveChanges();



                return Redirect("/Seed/Detail/" + seedId);
            }
            return View(viewModel);

        }
        
        //this will get the values
        //[HttpPost]
        //public IActionResult GatherBedInfo(int[] bedIds)
        //{
        //    foreach (int bedId in bedIds)
        //    {
        //        Bed theBed = context.Beds.Find(bedId);


        //        context.SaveChanges();

        //    }
        //    return View("EditBed", );
        

        //[HttpPost]
        //public IActionResult EditBed(int[] bedIds)
        //{
        //    foreach (int bedId in bedIds)
        //    {
        //        Bed theBed = context.Beds.Find(bedId);

        //        theBed.Name = name;


        //        context.SaveChanges();

        //    }
        //    return View("Index");
        //}



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
            .Include(j => j.Seeds)
            .Single(j => j.Id == id);

            //Load THE SEEDS on the view model

            BedDetailViewModel viewModel = new BedDetailViewModel(theBed);
            return View(viewModel);
        }
    }
}
      

