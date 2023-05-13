using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Policy;

namespace Tracker.Models
{
    public class Water
    {

        public int Id { get; set; }

        public DateTime DatePlanted { get; set; }

        public DateTime WaterTime { get; set; }

        //public bool IsItTime { get; set; }

        public virtual ICollection<SeedWaterBed>? SeedWaterBed { get; set; }

        public string Seedname { get; set; }

        public string Bedname { get; set; }

        public Water(DateTime datePlanted)
        {

            DatePlanted = datePlanted;
            WaterTime = ConvertWaterToTime();
            SeedWaterBed = new HashSet<SeedWaterBed>();
        }
        public Water()
        {

        }

        public DateTime ConvertWaterToTime()
        {
            ////if (waterSchedule == null || datePlanted == null )
            ////{
            ////    return null;
            //}

            foreach (SeedWaterBed waterBed in SeedWaterBed)
            {

                if (waterBed.Seed.WaterSchedule == "1")
                {
                    WaterTime = DatePlanted.AddDays(7);
                }
                else if (waterBed.Seed.WaterSchedule == "2")
                {
                    WaterTime = DatePlanted.AddDays(3);
                }
                else if (waterBed.Seed.WaterSchedule == "3")
                {
                    WaterTime = DatePlanted.AddDays(14);
                }
                else if (waterBed.Seed.WaterSchedule == "4")
                {
                    WaterTime = DatePlanted.AddSeconds(5);
                }
            }
                return (WaterTime);
            
        }
        //public bool IsItTimeToWater()
        //{
        //    if (WaterTime >= DateTime.UtcNow)
        //        return (IsItTime = true);
        //    else
        //    {
        //        return (IsItTime = false);
        //    }
            
        //}

        public String SeedName()
        {

            foreach (SeedWaterBed seed in SeedWaterBed)
            {
                Seedname = seed.Seed.Name;

            }
            return (Seedname);
        }

        public String BedName()
        {

            foreach (SeedWaterBed bed in SeedWaterBed)
            {
                Bedname = bed.Bed.Name;

            }
            return (Bedname);
        }
    }
}




