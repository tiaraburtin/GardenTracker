using Microsoft.AspNetCore.Mvc.Rendering;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class AddBedViewModel
    {
        public int BedId { get; set; }
        public string? Name { get; set; }

        public int WaterId { get; set; }

        public Bed? Bed { get; set; }

        public Water? Water { get; set; }

        public bool? IsItTime { get; set; }

        public List<SelectListItem>? Beds { get; set; }

        public AddBedViewModel(Water theWater, List<Bed> possibleBeds)
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

            Water = theWater;
        }

        public AddBedViewModel()
        {
        }

    }
}


