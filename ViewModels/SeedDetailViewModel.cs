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

            List<Water> bednames = theSeed.Waters.ToList();

            for (int i = 0; i < bednames.Count; i++)
            {
                BedNames += (bednames[i].BedName());
                if (i < bednames.Count - 1)
                {
                    BedNames += ", ";
                }
            }

        }
    }
}