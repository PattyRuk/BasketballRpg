using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Entities
{
    public class Forward : Player
    {
        public string Name { get; }
        public int Health => 92;
        public int Defense => 15;
        public int Speed => 14;
        public int Strength => 14;
        public int Intellect => 13;
        public int Agility => 13;

        public int JerseyNumber { get; set; } = 0;
        public string Hometown { get; set; } = "Undrafted Pool";


    }
}
