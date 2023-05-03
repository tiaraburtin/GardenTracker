using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Tracker.Models;


namespace Tracker.ViewModels
{
    public class AddSeedViewModel
    {
        public int SeedId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage =
         "Name must be between 2 and 30 characters long")]
        public string Name { get; set; }

        public int BedId { get; set; }

        public Bed? Bed { get; set; }

        public Seed? Seed { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime DatePlanted { get; set; }
        [Required(ErrorMessage = "HardinessZone is required")]
        public string HardinessZone { get; set; }

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