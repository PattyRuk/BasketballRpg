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
                    HandleTraining();
                    break;
                case "3":
                    HandleInventory();
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


    }
}
