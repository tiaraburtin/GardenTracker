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
        public IActionResult AddBed(AddBedViewModel addBedViewModel)
        {
            if (ModelState.IsValid)
            {
                Bed newBed = new Bed
                {
                    Name = addBedViewModel.Name,   

                };
                context.Beds.Add(newBed);
                context.SaveChanges();

                return Redirect("/Bed/");
            }
            else
            {
                return View("Add",addBedViewModel);


            }
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

                //is binding the seedId to the BedId from the viewModel
                //
                Seed theSeed = context.Seeds.Where(j => j.Id == seedId).First();

                Bed theBed = context.Beds.Where(s => s.Id == bedId).First();

                theSeed.Beds.Add(theBed);

                context.SaveChanges();

                return Redirect("/Seed/Detail/" + seedId);
            }
            return View(viewModel);
            
        }
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
            .Include(j => j.Seeds)
            .Single(j => j.Id == id);

            //Load THE SEEDS on the view model

            BedDetailViewModel viewModel = new BedDetailViewModel(theBed);
            return View(viewModel);
        }
    }
}
      

