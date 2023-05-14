using System;

namespace Tracker.Models
{
    public class SeedWaterBed
    {
        public int SeedId { get; set; }

        public int WaterId { get; set; }

        public int BedId { get; set; }

        public virtual Seed Seed { get; set; }

        public virtual Water Water { get; set; }

        public virtual Bed Bed { get; set; }
    }


    public string GetWaterTime()
    {
        ////if (waterSchedule == null || datePlanted == null )
        ////{
        ////    return null;
        //}
        foreach (Seed seed in Seed)
        {
            if (Seed.WaterSchedule == null)
            {
                return ("10000");
            }

            if (Seed.WaterSchedule == "1")
            {
                WaterTime = "604800000";
                //DatePlanted.AddDays(7);
            }
            else if (waterBed.Seed.WaterSchedule == "2")
            {
                WaterTime = "259200000";
                //DatePlanted.AddDays(3);
            }
            else if (waterBed.Seed.WaterSchedule == "3")
            {
                WaterTime = "1209600000";
                //DatePlanted.AddDays(14);
            }
            else if (waterBed.Seed.WaterSchedule == "4")
            {
                WaterTime = "10000";
                //DatePlanted.AddSeconds(10);
            }
            return (WaterTime);
        }

    }
}
