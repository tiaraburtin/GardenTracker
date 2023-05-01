namespace Tracker.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DatePlanted { get; set; }

        public string HardinessZone { get; set; }

        public ICollection<Bed> Beds { get; set; }    

        public Seed(string name, DateTime datePlanted, string hardinessZone)
        {
            Name = name;
            DatePlanted = datePlanted;
            Beds = new List<Bed>();
            HardinessZone = hardinessZone;
        }
        public Seed() 
        { 
            Beds = new List<Bed>();
        }
    }
}
