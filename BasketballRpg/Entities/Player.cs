using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Entities
{
    public interface Player
    {
        string Name { get; }
        int Health { get; }      // Stamina
        int Defense { get; }     // Defensive Coverage
        int Speed { get; }       // Acceleration
        int Strength { get; }    // Physicality
        int Intellect { get; }   // Court Vision / IQ
        int Agility { get; }     // Ball Handles

        int JerseyNumber { get; set; }
        string Hometown { get; set; }

        void Act();
        void Speak();
        void PrintDetails();
    }
}
