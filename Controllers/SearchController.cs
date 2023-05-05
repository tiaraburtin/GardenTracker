using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tracker.Data;
using Tracker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.Controllers
{
    public class SearchController : Controller
    {
        private TrackerDbContext context;
        private UserManager<IdentityUser> UserManager;

        public SearchController(TrackerDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index(string searchTerm)
        { 
            if (searchTerm != null)
            {

                string id = UserManager.GetUserId(User);
                string lowerSearch = searchTerm.ToLower();
                List<Seed> searchResults = new List<Seed>();
                List<Seed> seed = context.Seeds.Where(x => x.Name.Contains(lowerSearch) && x.UserId == id).ToList();
                if (seed != null)
                {
                    foreach (var seedSearchR in seed)
                    {
                        var seedNameToLower = seedSearchR.Name.ToLower();
                        if (seedNameToLower.Contains(lowerSearch))
                        {

                            searchResults.Add(seedSearchR);
                        }
                    }
                    return View(searchResults);
                }
                
            }
          
            return View();

        }
    }
}

