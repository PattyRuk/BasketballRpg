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

        public Player ProcessBadges(Player activePlayer)
        {
            Console.WriteLine("Available Specialization Upgrades:\n1. Three-Point Sniper Badge\n2. Lockdown Defender Badge");
            Console.Write("Select training focus: ");
            string choice = Console.ReadLine()?.Trim() ?? "";

            Player updatedPlayer = activePlayer;

            if (choice == "1")
            {
                updatedPlayer = new SniperBadge(activePlayer);
                Console.WriteLine($"\n[Upgrade Log] {updatedPlayer.Name} unlocked the Sniper badge modification.");
            }
            else if (choice == "2")
            {
                updatedPlayer = new LockdownBadge(activePlayer);
                Console.WriteLine($"\n[Upgrade Log] {updatedPlayer.Name} unlocked the Lockdown Defender badge modification.");
            }
            else
            {
                Console.WriteLine("\nNotice: Drill skipped due to unrecognized choice.");
            }

            updatedPlayer.PrintDetails();
            return updatedPlayer;
        }
        public void OpenLockerRoom(LockerRoom lockerRoom)
        {
            Console.WriteLine("Locker Room Management:\n1. Track New Item\n2. Display Full Locker\n3. Filter Item by Category");
            Console.Write("Enter selection: ");
            string choice = Console.ReadLine()?.Trim() ?? "";

            if (choice == "1")
            {
                Console.Write("Enter Item Name (e.g. 'Ankle Braces', 'Sports Drink'): ");
                string name = Console.ReadLine()?.Trim() ?? "Standard item";
                Console.Write("Enter Category (Equipment / Medical / Consumable): ");
                string category = Console.ReadLine()?.Trim() ?? "Equipment";

                lockerRoom.GetItem(name, category);
            }
            else if (choice == "2")
            {
                lockerRoom.DisplayItems();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filter criteria keyword (Equipment, Medical, or Consumable): ");
                string filter = Console.ReadLine()?.Trim() ?? "";
                lockerRoom.DisplayItemByCategory(filter);
            }
            else
            {
                Console.WriteLine("Notice: Action cancelled. Invalid option.");
            }
        }
        public void ExecuteSimulation(Player? player)
        {
            if (player == null)
            {
                Console.WriteLine("Notice: No Active Players Found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            player.PrintDetails();
            player.Speak();
            player.Act();
            Console.ResetColor();
        }
        public void ModifyLeagueSettings(LeagueSimulation leagueHub)
        {
            Console.Write("Change League Game Mode (Arcade / NBA Live / StreetBall): ");
            leagueHub.GameMode = Console.ReadLine()?.Trim() ?? "Arcade";

            Console.Write("Advance Court Period (1st Quarter / 2nd Quarter / 3rd Quarter / 4th Quarter): ");
            leagueHub.MatchQuarter = Console.ReadLine()?.Trim() ?? "1st Quarter";
        }
    }
}