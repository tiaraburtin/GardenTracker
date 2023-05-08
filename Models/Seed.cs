using System.Security.Policy;

namespace Tracker.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? WaterSchedule { get; set; }

        public string? HardinessZone { get; set; }
  
        public ICollection<Water>? Waters { get; set; }
        public Seed(string name, string hardinessZone, string waterSchedule)
        {
            Name = name;
            //Beds = new List<Bed>();
            HardinessZone = hardinessZone;
            WaterSchedule = waterSchedule;
            Waters = new List<Water>();

        }
        public Seed()
        {
            //Beds = new List<Bed>();
        }

 
    }
}