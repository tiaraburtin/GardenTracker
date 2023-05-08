using Microsoft.AspNetCore.Mvc.Rendering;
using Tracker.Models;


namespace Tracker.ViewModels
{
    public class AddSeedViewModel
    {
        public int SeedId { get; set; }
        public int WaterId { get; set; }

        public string? Name { get; set; }
        public Water? Water { get; set; }

       
        public string? WaterSchedule { get; set; }
      
        public string HardinessZone { get; set; }

        public List<SelectListItem>? Seeds { get; set; }

        public AddSeedViewModel(Water theWater, List<Seed> possibleSeeds)
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
            //why do we need this?
            Water = theWater;
        }

        public AddSeedViewModel()
        {
        }
    }
}