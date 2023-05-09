using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Tracing;
using Tracker.Models;

namespace Tracker.ViewModels
{
	public class SeedDetailViewModel
	{
		public int SeedId { get; set; }
		public string? Name { get; set; }

		public Seed? Seed { get; set; }

		public string BedText { get; set; }

		public string HardinessZone { get; set; }

		public DateTime DatePlanted { get; set;}

		public string WaterSchedule { get; set; }

		public SeedDetailViewModel(Seed theSeed)
		{
			SeedId = theSeed.Id;
			Name = theSeed.Name;
			BedText = "";
			List<Bed> beds = theSeed.Beds.ToList();
            DatePlanted = theSeed.DatePlanted;
            HardinessZone = theSeed.HardinessZone;
			WaterSchedule = theSeed.WaterSchedule;

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
}