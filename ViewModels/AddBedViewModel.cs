using Microsoft.AspNetCore.Mvc.Rendering;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class AddBedViewModel
    {
        public int BedId { get; set; }
        public string? Name { get; set; }

        public int SeedId { get; set; }

        public Bed? Bed { get; set; }

        public Seed? Seed { get; set; }

        public string SeedText { get; set; }

        public List<SelectListItem>? Beds { get; set; }

        public AddBedViewModel(Seed theSeed, List<Bed> possibleBeds)
        {

            Beds = new List<SelectListItem>();
            foreach (var bed in possibleBeds)
            {
                Beds.Add(new SelectListItem
                {
                    Value = bed.Id.ToString(),
                    Text = bed.Name,
                });
            }


            Seed = theSeed;
        }

        public AddBedViewModel()
        {
        }

    }
}


