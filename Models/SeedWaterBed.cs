namespace Tracker.Models
{
    public class SeedWaterBed
    {
        public int SeedId { get; set; }

        public int WaterId { get; set; }

        public int BedId { get; set; }

        public virtual Seed Seed { get; set; }

        public virtual Water Water { get; set; }

        public virtual Bed Bed { get; set; }
    }
}
