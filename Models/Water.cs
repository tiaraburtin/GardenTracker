using System.Security.Policy;

namespace Tracker.Models
{
    public class Water
    {
        public int Id { get; set; }


        public DateTime DatePlanted { get; set; }

        public DateTime NeedsWater { get; set; }

        public ICollection<Seed>? Seeds { get; set; }

        public ICollection<Bed>? Beds { get; set; }

        public Water(DateTime datePlanted, DateTime needsWater)
        {

            DatePlanted = datePlanted;
            NeedsWater = ConvertWaterToTime(this.DatePlanted);
            Beds = new List<Bed>();
    }
        public Water()
            {

            }

        public DateTime ConvertWaterToTime(DateTime datePlanted)
        {
            ////if (waterSchedule == null || datePlanted == null )
            ////{
            ////    return null;
            //}

            foreach (Seed seed in Seeds)
            {
                if (seed.WaterSchedule == "1")
                {
                    NeedsWater = datePlanted.AddDays(7);
                }
                else if (seed.WaterSchedule == "2")
                {
                    NeedsWater = datePlanted.AddDays(3);
                }
                else if (seed.WaterSchedule == "3")
                {
                    NeedsWater = datePlanted.AddDays(14);
                }
                else if (seed.WaterSchedule == "4")
                {
                    NeedsWater = datePlanted.AddMinutes(1);
                }
                return (NeedsWater);
            }
            return (NeedsWater);
        }

    }
}



