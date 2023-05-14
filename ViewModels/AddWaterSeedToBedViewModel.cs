using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Tracker.Models;

namespace Tracker.ViewModels
{

    public class AddWaterSeedToBedViewModel
    {

        public int WaterId { get; set; }
        // public Water Water { get; set; }
        // public Bed Bed { get; set; }

        public DateTime DatePlanted { get; set; }
        public string? WaterTime { get; set; }

        public List<SelectListItem>? Seed { get; set; }
        public int SeedId { get; set; }
        public List<SelectListItem>? Waters { get; set; }
        public int BedId { get; set; }

        public AddWaterSeedToBedViewModel(Water? theWater, List<Seed>? seeds)
        {
            Seed = new List<SelectListItem>();

            foreach (var seed in seeds)
            {
                Seed.Add(new SelectListItem
                {
                    Value = seed.Id.ToString(),
                    Text = seed.Name,
                 
                });

                //WaterTime = seed.WaterTime;
            }

            
            //Water = theWater;
        }

        public AddWaterSeedToBedViewModel(Bed? theBed, List<Water>? waters)
        {
            Waters = new List<SelectListItem>();
        
            foreach (var water in waters)
            {
                Waters.Add(new SelectListItem
                {
                    Value = water.Id.ToString(),
                    
                });
            }
            
            // Bed = theBed;
        }

        public AddWaterSeedToBedViewModel(Bed theBed, List<Seed> seeds)
        {
            Seed = new List<SelectListItem>();
            
            foreach (var seed in seeds)
            {
                Seed.Add(new SelectListItem
                {
                    Value = seed.Id.ToString(),
                    Text = seed.Name,
                });
            }

            // Bed = theBed;
            BedId = theBed.Id;
            DatePlanted = DateTime.Now;
        }

        public AddWaterSeedToBedViewModel()
        {
        }
    }

}