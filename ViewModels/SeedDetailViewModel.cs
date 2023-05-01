using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Tracing;
using Tracker.Models;

namespace Tracker.ViewModels
{
	public class SeedDetailViewModel
	{
		public int SeedId { get; set; }
		public string? Name { get; set; }

		public Seed Seed { get; set; }

		public string BedText { get; set; }

		public SeedDetailViewModel(Seed theSeed)
		{
			SeedId = theSeed.Id;
			Name = theSeed.Name;
			BedText = "";
			List<Bed> beds = theSeed.Beds.ToList();

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
		//public SeedDetailViewModel()
		//{
		//	Beds = new List<Bed>();
		//}
	}
}