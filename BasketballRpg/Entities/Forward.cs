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

        public Forward(string name) => Name = name;

        public void Act() => Console.WriteLine($"{Name} maps out space along the baseline, rises up, and scores a crisp mid-range fadeaway.");
        public void Speak() => Console.WriteLine($"\"{Name} signals: Switch configurations! I've picked up the perimeter driver!\"");

        public void PrintDetails()
        {
            Console.WriteLine($"--- #{JerseyNumber} {Name} (Position: Forward from {Hometown}) ---\n" +
                              $"Stamina: {Health} | Defensive Coverage: {Defense} | Acceleration: {Speed} | Physicality: {Strength} | Court Vision: {Intellect} | Handle Control: {Agility}");
        }
    }
}
