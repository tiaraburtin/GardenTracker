using Microsoft.AspNetCore.Mvc.Rendering;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class AddBedViewModel
    {
        public string? Name { get; set; }

        public DateTime DatePlanted { get; set; }
        public List<SelectListItem>? Seeds { get; set; }

        public AddBedViewModel(Bed theBed, List<Seed> possibleSeeds, DateTime DatePlanted) 
        {
            Seeds = new List<SelectListItem>();
            foreach (var seed in possibleSeeds) 
            {
                Seeds.Add(new SelectListItem
                {
                    Value = seed.Id.ToString(),
                    Text = seed.Name,
                });
            }
        }

        public AddBedViewModel() 
        { 
        }

    }
}

//We can add seeds from a drop-down, but we do not add hardiZones bc hardiZones
//have already been added to seeds in the AddSeedViewModel class
