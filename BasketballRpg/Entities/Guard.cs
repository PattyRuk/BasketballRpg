using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Entities
{
    public class Guard : Player
    {
        public string Name { get; }
        public int Health => 90;
        public int Defense => 12;
        public int Speed => 18;
        public int Strength => 8;
        public int Intellect => 15;
        public int Agility => 19;

        public int JerseyNumber { get; set; } = 0;
        public string Hometown { get; set; } = "Undrafted Pool";

       
    }
}
