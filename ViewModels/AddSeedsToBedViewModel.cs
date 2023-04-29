using Microsoft.AspNetCore.Mvc.Rendering;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class AddSeedsToBedViewModel
    {
        public int BedId { get; set; }
        public Bed? Bed { get; set; }
        public List<SelectListItem>? Seeds { get; set; }    

        public int SeedId { get; set; }

        public AddSeedsToBedViewModel(Bed thebed, List<Seed> possibleSeeds) 
        {
            Seeds = new List<SelectListItem>();

            foreach (var seed in possibleSeeds)
            {
                Seeds.Add(new SelectListItem
                {
                    Value = seed.Id.ToString(),
                    Text = seed.Name
                });
            }
            Bed = thebed;
        }
        public AddSeedsToBedViewModel()
        {
        }
    }
}
//make sure this view model works with seed/addSeedToBedViewModel
