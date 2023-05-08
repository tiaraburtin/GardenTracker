
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Tracing;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class BedDetailViewModel
    {
        public int BedId { get; set; }
        public string? Name { get; set; }

        public Bed? Bed { get; set; }

        public Water? Water { get; set; }

        //public string SeedText { get; set; }

        //how to rewrite this to where the bed detail is showing the seeds in the bed and their water schedule
        //maybe we dont need this
        public BedDetailViewModel(Water theWater)
        {
            WaterId = Water.Id;
           
            //how do i add the individual seed with water details?
            List < Water > theWater = theWater.ToList();


            //BedId = theWater.Id;
            //Name = Seeds.Name;
            //BedText = "";
            //List<Bed> beds = theSeed.Beds.ToList();

            for (int i = 0; i < beds.Count; i++)
            {
                BedText += (beds[i].Name);
                if (i < beds.Count - 1)
                {
                    BedText += ", ";
                }
            }
            Seed = theSeed;
        }
    }