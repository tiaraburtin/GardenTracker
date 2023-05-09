using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Policy;

namespace Tracker.Models
{
    [Keyless]

    public class Water
    {

        public int Id { get; set; }

        public DateTime DatePlanted { get; set; }

        public DateTime NeedsWater { get; set; }

        public ICollection<Seed>? Seeds { get; set; }

        public ICollection<Bed>? Beds { get; set; }

        public string Seedname { get; set; }

        public string Bedname { get; set; }

        public Water(DateTime datePlanted)
        {

            DatePlanted = datePlanted;
            NeedsWater = ConvertWaterToTime();
            Beds = new List<Bed>();
            Seeds = new List<Seed>();
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

            foreach (Seed seed in Seeds)
            {
                if (seed.WaterSchedule == "1")
                {
                    NeedsWater = DatePlanted.AddDays(7);
                }
                else if (seed.WaterSchedule == "2")
                {
                    NeedsWater = DatePlanted.AddDays(3);
                }
                else if (seed.WaterSchedule == "3")
                {
                    NeedsWater = DatePlanted.AddDays(14);
                }
                else if (seed.WaterSchedule == "4")
                {
                    NeedsWater = DatePlanted.AddMinutes(1);
                }
                return (NeedsWater);
            }
            return (NeedsWater);
        }


        public String SeedName()
        {

            foreach (Seed seed in Seeds)
            {
                Seedname = seed.Name;

            }
            return (Seedname);
        }

        public String BedName()
        {

            foreach (Bed bed in Beds)
            {
                Bedname = bed.Name;

            }
            return (Bedname);
        }
    }
}




