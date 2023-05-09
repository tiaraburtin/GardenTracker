using System;

namespace Tracker.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SeedWaterBed>? SeedWaterBed { get; set; }


        public Bed(string name)
        {
            Name = name;
            SeedWaterBed = new HashSet<SeedWaterBed>();
        }

        public Bed()
        {
            SeedWaterBed = new HashSet<SeedWaterBed>();
        }
    }
}