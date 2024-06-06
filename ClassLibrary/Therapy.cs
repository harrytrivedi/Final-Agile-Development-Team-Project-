using System;

namespace Medi2GoLibrary.Models
{
    public class Therapy
    {
        public int TEId { get; set; }
        public string Username { get; set; }
        public string TheraName { get; set; }
        public string TheraTime { get; set; }
        public string TheraDate { get; set; }
        public decimal Price { get; set; } 

        // Constructor
        public Therapy()
        {
            
            TEId = 0;
            Username = "";
            TheraName = "";
            TheraTime = "";
            TheraDate = "";
            Price = 0;
        }
    }
}
