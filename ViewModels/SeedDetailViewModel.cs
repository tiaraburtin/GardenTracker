using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using System.Diagnostics.Tracing;
using Tracker.Models;

namespace Tracker.ViewModels
{
	public class SeedDetailViewModel
{
	public int SeedId { get; set; }
	public string? Name { get; set; }

     public string BedNames { get; set; }


        //how to rewrite this to where the seed detail is showing the beds and the water (dateplanted)
        //maybe we dont need this?
        public SeedDetailViewModel(Seed theSeed)
        {
            SeedId = theSeed.Id;
            Name = theSeed.Name;

            List<SeedWaterBed> bednames = theSeed.SeedWaterBed.ToList();

            for (int i = 0; i < bednames.Count; i++)
            {
                BedNames += (bednames[i].Bed.Name);
                if (i < bednames.Count - 1)
                {
                    BedNames += ", ";
                }
            }

        }
    }
}