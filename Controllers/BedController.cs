
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using Tracker.ViewModels;
using Tracker.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;

namespace Tracker.Controllers
{
    [Authorize]
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
    }

}        

