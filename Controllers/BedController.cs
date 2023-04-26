
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using Tracker.ViewModels;
using Tracker.Data;

namespace Tracker.Controllers
{
    public class BedController : Controller
    {
        private TrackerDbContext context;

        public BedController (TrackerDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Bed> beds = context.Beds.ToList(); 
            return View(beds);
        }

        [HttpPost]
        public IActionResult Add()
        {
           AddSeedViewModel addSeedViewModel = new AddSeedViewModel();
            return View(addSeedViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddBedForm(AddBedViewModel addBedViewModel)
        {
            if (ModelState.IsValid)
            {
                Bed newBed = new Bed
                {
                    Name = addBedViewModel.Name,
                    DatePlanted = addBedViewModel.DatePlanted
                };
                context.Beds.Add(newBed);
                context.SaveChanges();

                return Redirect("/Seed");
            }
            else
            {
                return View("Create", addBedViewModel);
            }
        }
    }
}
