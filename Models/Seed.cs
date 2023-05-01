namespace Tracker.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bed> Beds { get; set; }    

        public Seed(string name)
        {
            Name = name;
            Beds = new List<Bed>();
        }
        public Seed() 
        { 
            Beds = new List<Bed>();
        }
    }
}
