using Microsoft.AspNetCore.Mvc.Rendering;
using Tracker.Models;


namespace Tracker.ViewModels

{
    public class AddSeedViewModel 
    {
    public string? Name { get; set; }
    public int? BedId { get; set; }

    public List<SelectListItem>? HardiZone { get; set; }

    public List<SelectListItem>? Beds { get; set; }

        public AddSeedViewModel(Seed theSeed, List<Bed> possibleBeds, List<HardiZone> possibleHardiZones) 
        {
            Beds = new List<SelectListItem>();
            foreach (var bed in possibleBeds )
            {
                Beds.Add(new SelectListItem
                {
                    Value = bed.Id.ToString(),
                    Text = bed.Name,
                });
            }
        }

        public AddSeedViewModel() 
        { 
        }
    }
}
//When you add a seed you can add multiple garden beds and or hardiness zones to this specific seed
