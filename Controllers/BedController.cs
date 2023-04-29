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
      

