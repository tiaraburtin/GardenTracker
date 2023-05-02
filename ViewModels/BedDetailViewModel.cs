
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Tracing;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class BedDetailViewModel
    {
        public int BedId { get; set; }
        public string? Name { get; set; }

        public Bed Bed { get; set; }

        public Seed? Seed { get; set; }

        public string SeedText { get; set; }

        public BedDetailViewModel(Bed theBed)
        {
            BedId = theBed.Id;
            Name = theBed.Name;
            SeedText = "";
            List<Seed> seeds = theBed.Seeds.ToList();

            for (int i = 0; i < seeds.Count; i++)
            {
                SeedText += (seeds[i].Name);
                if (i < seeds.Count - 1)
                {
                    SeedText += ", ";
                }
            }
            Bed = theBed;
        }
    }
}