using System;

namespace Tracker.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DatePlanted { get; set; }

        public string HardinessZone { get; set; }   

        public ICollection<Seed> Seeds { get; set; }


    public Bed(string name, DateTime datePlanted, string hardinessZone)
        {
            Name = name;
            DatePlanted = datePlanted;
            Seeds = new List<Seed>();
            HardinessZone = hardinessZone;
        }
         public Bed() 
        {
            Seeds = new List<Seed>();
        }    
    }
}
