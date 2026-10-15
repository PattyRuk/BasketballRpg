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

        public Center(string name) => Name = name;

        public void Act() => Console.WriteLine($"{Name} seals the defender deep inside the lower key and finishes with an aggressive dunk!!");
        public void Speak() => Console.WriteLine($"\"{Name} booms: Protect the glass! Grab that rebound and run!\"");

        public void PrintDetails()
        {
            Console.WriteLine($"--- #{JerseyNumber} {Name} (Position: Center from {Hometown}) ---\n" +
                              $"Stamina: {Health} | Rim Defensive Coverage: {Defense} | Acceleration: {Speed} | Physicality: {Strength} | Court Vision: {Intellect} | Ball Handle: {Agility}");
        }
    }
}
