using System;

namespace Tracker.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ICollection<Water>? Waters { get; set; }



        public Bed(string name)
        {
            Name = name;
            Waters = new List<Water>();

        }
         public Bed() 
        {
   
        }    
       
    }
}
