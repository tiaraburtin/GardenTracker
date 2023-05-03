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
using Microsoft.AspNetCore.Identity;

namespace Tracker.Controllers
{
    public class BedController : Controller
    {
        private UserManager<IdentityUser> UserManager;
        private TrackerDbContext context;

        public BedController(TrackerDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
            context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            string id = UserManager.GetUserId(User);
            List<Bed> beds = context.Beds.Where(b => b.UserId == id).ToList();
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
                    UserId = addBedViewModel.UserId
                    
                };

                context.Beds.Add(newBed);
                context.SaveChanges();

                return Redirect("/Bed/");
            }
            return View("Add", addBedViewModel);
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

        [HttpPost]
        public IActionResult gatherBeds(int[] editIds)
        {
            List<Bed> bedstoedit = new List<Bed>();
            foreach (int bedid in editIds)
            {
                Bed thebed = context.Beds.Find(bedid);
                bedstoedit.Add(thebed);

                context.SaveChanges();

            }
            return View("EditBed", bedstoedit);
        }

        [HttpPost]
        public IActionResult EditBedSubmit(int[] bedIds, string[] beds)
        {

            for (int i = 0; i < bedIds.Length; i++)
            {
                Bed bed = context.Beds.Find(bedIds[i]);
                bed.Name = beds[i];
            }

            context.SaveChanges();

            return Redirect("Index");
        }
            [HttpPost]
        public IActionResult DeleteBed(int[] deleteIds)
        {
            foreach (int bedId in deleteIds)
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
      

