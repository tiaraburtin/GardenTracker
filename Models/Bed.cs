using System;

namespace Tracker.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public ICollection<Seed>? Seeds { get; set; }


    public Bed(string name)
        {
            Name = name;
            Seeds = new List<Seed>();
        }
         public Bed() 
        {
            Seeds = new List<Seed>();
        }    
       
    }
}
