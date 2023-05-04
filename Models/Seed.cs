using System.Security.Policy;

namespace Tracker.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HardinessZone { get; set; }

        public DateTime DatePlanted { get; set; }

        public int WaterSchedule { get; set; }

        public ICollection<Bed>? Beds { get; set; }    

        public Seed(string name, string hardinessZone, DateTime datePlanted, int waterSchedule)
        {
            Name = name;
            Beds = new List<Bed>();
            HardinessZone = hardinessZone;
            DatePlanted = datePlanted;
            WaterSchedule = waterSchedule;
        }
        public Seed() 
        { 
            Beds = new List<Bed>();
        }
    }
}
