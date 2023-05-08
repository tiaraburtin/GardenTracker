using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Tracker.Models;

namespace Tracker.ViewModels
{

    public class AddWaterSeedToBedViewModel
    {

        public int WaterId { get; set; }
        public Water? Water { get; set; }

        public List<SelectListItem>? Seed { get; set; }
        public int SeedId { get; set; }
        public List<SelectListItem>? Bed { get; set; }
        public int BedId { get; set; }

        public AddWaterSeedToBedViewModel(Water theWater, List<Seed> seeds)
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

            Water = theWater;
        }

        public AddWaterSeedToBedViewModel(Water theWater, List<Bed> beds)
        {
            Bed = new List<SelectListItem>();

            foreach (var bed in beds)
            {
                Bed.Add(new SelectListItem
                {
                    Value = bed.Id.ToString(),
                    Text = bed.Name,
                });
            }

            Water = theWater;
        }

        public AddWaterSeedToBedViewModel()
        {
        }
    }

}