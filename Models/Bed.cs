using System;

namespace Tracker.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SeedWaterBed>? SeedWaterBed { get; set; }

        public bool IsItTime { get; set; }
        public Water Water { get; set; }

        public Bed(string name)
        {
            Name = name;
            SeedWaterBed = new HashSet<SeedWaterBed>();
        }

        public Bed()
        {
            SeedWaterBed = new HashSet<SeedWaterBed>();
        }

        public bool IsItTimeToWater()
        {

            if (Water.WaterTime >= DateTime.UtcNow)
                return (IsItTime = true);
            else
            {
                return (IsItTime = false);
            }

        }


    }
}