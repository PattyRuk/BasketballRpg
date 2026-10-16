using BasketballRpg.Entities;
using BasketballRpg.Factories;
using BasketballRpg.Inventory;
using BasketballRpg.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg
{
    public class SimulationController
    {
        private readonly LeagueSimulation _leagueHub;
        private readonly LockerRoom _lockerRoom;
        private Player? _draftedPlayer;
        private bool _isRunning;

        public SimulationController()
        {
            _leagueHub = LeagueSimulation.Instance;
            _lockerRoom = new LockerRoom();
            _isRunning = true;
        }

        public void RunEngineLoop()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== BASKETBALL FANTASY RPG ENGINE ===");
            Console.ResetColor();

            while (_isRunning)
            {
                PrintMenuOptions();
                string choice = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();
                ProcessInput(choice);
            }
        }

        private void PrintMenuOptions()
        {
            Console.WriteLine("\n==============================================");
            _leagueHub.PrintLeagueStatus();
            Console.WriteLine("1. Draft & Customize Player");
            Console.WriteLine("2. Player Badges");
            Console.WriteLine("3. Locker Room Items");
            Console.WriteLine("4. Simulate Possession (Act/Speak/Stats)");
            Console.WriteLine("5. Configure League Settings");
            Console.WriteLine("6. Shut Down Simulation");
            Console.Write("Enter your selected choice: ");
        }

        private void ProcessInput(string choice)
        {
            switch (choice)
            {
                case "1":
                    HandleDrafting();
                    break;
                case "2":
                    HandleBadges();
                    break;
                case "3":
                    HandleItems();
                    break;
                case "4":
                    HandleSimulation();
                    break;
                case "5":
                    HandleGameSettings();
                    break;
                case "6":
                    _isRunning = false;
                    Console.WriteLine("Safely shutting down basketball simulation engine.");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[Error] Invalid. Please enter a number from 1 to 6.");
                    Console.ResetColor();
                    break;
            }
        }

        private void HandleDrafting()
        {
            Console.Write("Enter player jersey name: ");
            string name = Console.ReadLine()?.Trim() ?? "Rookie";

            Console.Write("Choose Court Position (Guard / Forward / Center): ");
            string position = Console.ReadLine()?.Trim() ?? "Guard";

            try
            {
                Player basicPlayer = PlayerFactory.CreatePlayer(position, name);

                Console.Write("Enter Custom Jersey Number (or leave blank for default 0): ");
                string jerseyInput = Console.ReadLine()?.Trim() ?? "";
                int.TryParse(jerseyInput, out int jerseyNum);

                Console.Write("Enter Custom Home College City (or leave blank): ");
                string homeTown = Console.ReadLine()?.Trim() ?? "Undrafted";

                _draftedPlayer = new PlayerCustomizer(basicPlayer)
                    .SetJerseyNumber(jerseyNum)
                    .SetHometown(homeTown)
                    .Build();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[Success] Player added successfully!");
                Console.ResetColor();
                _draftedPlayer.PrintDetails();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] {ex.Message}");
                Console.ResetColor();
            }
        }

        private void HandleBadges()
        {
            if (_draftedPlayer == null)
            {
                Console.WriteLine("Notice: Please draft/create a player via Option 1 before executing training drills.");
                return;
            }

            Console.WriteLine("Available Specialization Upgrades:\n1. Three-Point Sniper Badge\n2. Lockdown Defender Badge");
            Console.Write("Select training focus: ");
            string badgeChoice = Console.ReadLine()?.Trim() ?? "";

            if (badgeChoice == "1")
            {
                _draftedPlayer = new SniperBadge(_draftedPlayer);
                Console.WriteLine($"[Upgrade Log] {_draftedPlayer.Name} unlocked the Sniper badge modification.");
            }
            else if (badgeChoice == "2")
            {
                _draftedPlayer = new LockdownBadge(_draftedPlayer);
                Console.WriteLine($"[Upgrade Log] {_draftedPlayer.Name} unlocked the Lockdown Defender badge modification.");
            }
            else
            {
                Console.WriteLine("Notice: Drill skipped due to unrecognized choice.");
            }
            _draftedPlayer.PrintDetails();
        }

        private void HandleItems()
        {
            Console.WriteLine("Locker Room Management:\n1. Track New Item\n2. Display Full Locker\n3. Filter Item by Category");
            Console.Write("Enter selection: ");
            string choice = Console.ReadLine()?.Trim() ?? "";

            if (choice == "1")
            {
                Console.Write("Enter Item Name (e.g., 'Grip Socks', 'Ankle Braces', 'Sports Drink'): ");
                string name = Console.ReadLine()?.Trim() ?? "Standard item";
                Console.Write("Enter Category (Equipment / Medical / Consumable): ");
                string category = Console.ReadLine()?.Trim() ?? "Equipment";

                _lockerRoom.GetItem(name, category);
            }
            else if (choice == "2")
            {
                _lockerRoom.DisplayItems();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filter criteria keyword (Equipment, Medical, or Consumable): ");
                string filter = Console.ReadLine()?.Trim() ?? "";
                _lockerRoom.DisplayItemByCategory(filter);
            }
            else
            {
                Console.WriteLine("Notice: Action cancelled. Invalid option.");
            }
        }

        private void HandleSimulation()
        {
            if (_draftedPlayer == null)
            {
                Console.WriteLine("Notice: No Active Players Found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            _draftedPlayer.PrintDetails();
            _draftedPlayer.Speak();
            _draftedPlayer.Act();
            Console.ResetColor();
        }

        private void HandleGameSettings()
        {
            Console.Write("Change League Game Mode (Arcade / NBA Live/ StreetBall): ");
            _leagueHub.GameMode = Console.ReadLine()?.Trim() ?? "Arcade";

            Console.Write("Advance Court Period (1st Quarter / 2nd Quarter / 3rd Quarter / 4th Quarter): ");
            _leagueHub.MatchQuarter = Console.ReadLine()?.Trim() ?? "1st Quarter";
        }
    }
}
