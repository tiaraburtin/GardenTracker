using Microsoft.AspNetCore.Mvc.Rendering;
using Tracker.Models;


namespace Tracker.ViewModels
{
    public class AddSeedViewModel 
    {
		public int SeedId { get; set; }

        public string? Name { get; set; }

        public int BedId { get; set; }

        public Bed? Bed { get; set; }

        public Seed? Seed { get; set; }

        public List<SelectListItem>? Seeds { get; set; }

        public AddSeedViewModel(Bed theBed, List<Seed> possibleSeeds)
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
            Bed = theBed;
        }

        public AddSeedViewModel()
        {
        }
    }
}
//When you add a seed you can add multiple garden beds and or hardiness zones to this specific seed
