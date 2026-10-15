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

        public Guard(string name) => Name = name;

        public void Act() => Console.WriteLine($"{Name} does a lightning-quick crossover and explodes to the basket.");
        public void Speak() => Console.WriteLine($"\"{Name} screams: Watch out for the trailing back-cut screen!\"");

        public void PrintDetails()
        {
            Console.WriteLine($"--- #{JerseyNumber} {Name} (Position: Guard from {Hometown}) ---\n" +
                              $"Stamina: {Health} | Defensive Coverage: {Defense} | Acceleration: {Speed} | Physicality: {Strength} | Court Vision: {Intellect} | Ball Handle: {Agility}");
        }
    }
}
