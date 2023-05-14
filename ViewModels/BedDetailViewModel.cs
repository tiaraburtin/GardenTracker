using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Tracing;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class BedDetailViewModel
    {
        public int BedId { get; set; }
        public string? Name { get; set; }

        //public Bed? Bed { get; set; }

        //public Water? Water { get; set; }
        //public string? WaterTime { get; set; }

        public string SeedNames { get; set; }


        //how to rewrite this to where the bed detail is showing the seeds in the bed and their water schedule
        //maybe we dont need this
        public BedDetailViewModel(Bed theBed)
        {
            BedId = theBed.Id;
            Name = theBed.Name;
            //WaterTime = theBed.WaterTime;




           
            List<SeedWaterBed> seednames = theBed.SeedWaterBed.ToList();

            for (int i = 0; i < seednames.Count; i++)
            {
                SeedNames += (seednames[i].Seed.Name);
                if (i < seednames.Count - 1)
                {
                    SeedNames += ", ";
                }
            }
        }
    }
}