using BasketballRpg.Decorators;
using BasketballRpg.Entities;
using BasketballRpg.Factories;
using BasketballRpg.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg
{
    public class RpgInputEngine
    {
        public Player? DraftPlayer()
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine()?.Trim() ?? "Rookie";

            Console.Write("Choose player Position (Guard / Forward / Center / Mascot-Red / Mascot-Green / Mascot-Blue): ");
            string position = Console.ReadLine()?.Trim() ?? "Guard";


        }


    }
}