using System;
using System.Security.Policy;

namespace Tracker.Models
{
    public class Seed
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? WaterSchedule { get; set; }
        //public string? WaterTime { get; set; }

        public string? HardinessZone { get; set; }

        public virtual ICollection<SeedWaterBed>? SeedWaterBed { get; set; }

        public Seed(string name, string hardinessZone, string waterSchedule)
        {
            Name = name;
            //Beds = new List<Bed>();
            HardinessZone = hardinessZone;
            WaterSchedule = waterSchedule;
            //WaterTime = ConvertWaterToTime();
            SeedWaterBed = new HashSet<SeedWaterBed>();

        }
        public Seed()
        {
            SeedWaterBed = new HashSet<SeedWaterBed>();
        }

        //public string ConvertWaterToTime()
        //{
        //    //    ////if (waterSchedule == null || datePlanted == null )
        //    //    ////{
        //    //    ////    return null;
        //    //    //}

        //    //foreach (SeedWaterBed waterBed in SeedWaterBed)
        //    {

        //        if (WaterSchedule == "1")
        //        {
        //            WaterTime = "604800000";
        //            //DatePlanted.AddDays(7);
        //        }
        //        else if (WaterSchedule == "2")
        //        {
        //            WaterTime = "259200000";
        //            //DatePlanted.AddDays(3);
        //        }
        //        else if (WaterSchedule == "3")
        //        {
        //            WaterTime = "1209600000";
        //            //DatePlanted.AddDays(14);
        //        }
        //        else if (WaterSchedule == "4")
        //        {
        //            WaterTime = "10000";
        //            //DatePlanted.AddSeconds(10);
        //        }
        //    }
        //    return (WaterTime);
        //    }

}
}