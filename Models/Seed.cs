using System.Security.Policy;

namespace Tracker.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HardinessZone { get; set; }

        public DateTime? DatePlanted { get; set; }

        public int WaterSchedule { get; set; }
        public DateTime? NeedsWater { get; set; }
      

        public ICollection<Bed>? Beds { get; set; }

        public Seed(string name, string hardinessZone, DateTime datePlanted, int waterSchedule)
        {
            Name = name;
            Beds = new List<Bed>();
            HardinessZone = hardinessZone;
            DatePlanted = datePlanted;
            WaterSchedule = waterSchedule;
            NeedsWater = ConvertWaterToTime(this.WaterSchedule,this.DatePlanted);
        
        }
        public Seed()
        {
            Beds = new List<Bed>();
        }

        public DateTime ConvertWaterToTime(int waterSchedule, DateTime datePlanted)
        {
            if (waterSchedule == null || datePlanted == null )
            {
                return null;
            }
            
            if (waterSchedule == 1)
            {
                NeedsWater = datePlanted.AddDays(7);
            }
            else if (waterSchedule == 2)
            {
                NeedsWater = datePlanted.AddDays(3);
            }
            else if (waterSchedule == 3)
            {
                NeedsWater = datePlanted.AddDays(14);
            }
            else if (waterSchedule == 4)
            {
                NeedsWater = datePlanted.AddMinutes(1);
            }
            return (NeedsWater);
        }
    }
}