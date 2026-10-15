using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Entities
{
    public class Center : Player
    {
        public string Name { get; }
        public int Health => 95;
        public int Defense => 19;
        public int Speed => 9;
        public int Strength => 20;
        public int Intellect => 10;
        public int Agility => 7;

        public int JerseyNumber { get; set; } = 0;
        public string Hometown { get; set; } = "Undrafted Pool";

       
    }
}
