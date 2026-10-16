using BasketballRpg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Decorators
{
    public class SniperBadge : BadgeDecorator
    {
        public override int Intellect => badgedPlayer.Intellect + 25; 
        public override int Agility => badgedPlayer.Agility + 15;

        public SniperBadge(Player player) : base(player) { }

        public override void Act()
        {
            Console.WriteLine($"{Name} catches it deep behind the line, and hits a pure Sniper three-pointer.");
        }

        public override void Speak()
        {
            Console.WriteLine($"\"{Name} gloats: If your hand is down, my shot is up. Total cash!\"");
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($" >>> [Badge Modification Active: Legendary Sniper Tier | IQ +25, Ball Handle +15]");
        }
    }
}