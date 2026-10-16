using BasketballRpg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Decorators
{
    public class LockdownBadge : BadgeDecorator
    {
        public override int Defense => badgedPlayer.Defense + 30; 
        public override int Speed => badgedPlayer.Speed + 15;

        public LockdownBadge(Player player) : base(player) { }

        public override void Act()
        {
            Console.WriteLine($"{Name} mirrors the opponent's movements completely, seals their path, and blocks the field-goal attempt.");
        }

        public override void Speak()
        {
            Console.WriteLine($"\"{Name} yells: No paint access tonight! Welcome to maximum lockdown!\"");
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($" >>> [Badge Modification Active: Legendary Lockdown Tier | Defense +30, Speed +15]");
        }
    }
}
