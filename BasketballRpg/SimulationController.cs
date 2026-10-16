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

       
    }
}
