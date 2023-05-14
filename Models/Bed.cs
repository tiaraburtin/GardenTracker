using System;

namespace Tracker.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? WaterTime { get; set; }
        public virtual ICollection<SeedWaterBed>? SeedWaterBed { get; set; }


        //public bool? IsItTime { get; set; }


        public Bed(string name, bool isItTime)
        {
            Name = name;
            SeedWaterBed = new HashSet<SeedWaterBed>();
            WaterTime = GetWaterTime();

        }

        public Bed()
        {
            SeedWaterBed = new HashSet<SeedWaterBed>();
        }

        public string GetWaterTime()
        {
            ////if (waterSchedule == null || datePlanted == null )
            ////{
            ////    return null;
            //}

            foreach (SeedWaterBed waterBed in SeedWaterBed)
            {

                if (waterBed.Seed.WaterSchedule == "1")
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
            }
            return (WaterTime);







            //public bool? IsItTimeToWater()
            //
            //    if (SeedWaterBed != null)
            //    {
            //        foreach (var seedWaterBed in SeedWaterBed)
            //        {
            //            // Check if the seed associated with the SeedWaterBed needs watering
            //            if (seedWaterBed.Seed != null && seedWaterBed.Water != null &&
            //                seedWaterBed.Water.WaterTime >= DateTime.UtcNow)
            //            {
            //                return (WaterTime)
            //        }
            //    }

            //    return (IsItTime = false);


            //public bool? IsItTimeToWater()
            //{

            //    if (Water.WaterTime >= DateTime.UtcNow)
            //        return (IsItTime = true);
            //    else
            //    {
            //        return (IsItTime = false);
            //    }

            //}


        }
    }
}

