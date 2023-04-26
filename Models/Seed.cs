namespace WaterReminder.Models
{
    public class Seed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HardiZone { get; set; }

        public string WaterSchedule { get; set; }

        public int BedId { get; set; }

        public Bed Bed { get; set; }    


        public Seed(string name, string hardiZone, string waterSchedule)
        {
            Name = name;
            HardiZone = hardiZone;
            WaterSchedule = waterSchedule;
        }
    }
}
