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

            try
            {
                Player player = PlayerFactory.CreatePlayer(position, name);

                Console.Write("Enter Custom Jersey Number (or leave blank for default 0): ");
                string jerseyInput = Console.ReadLine()?.Trim() ?? "";
                int.TryParse(jerseyInput, out int jerseyNum);

                Console.Write("Enter Custom Home City/Location (or leave blank for Undrafted): ");
                string homeTown = Console.ReadLine()?.Trim() ?? "Undrafted";

                Player fullyBuiltPlayer = new PlayerCustomizer(player)
                    .SetJerseyNumber(jerseyNum)
                    .SetHometown(homeTown)
                    .Build();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[Success] Player added successfully!");
                Console.ResetColor();
                fullyBuiltPlayer.PrintDetails();
                return fullyBuiltPlayer;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }


    }
}