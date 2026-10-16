using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg
{
    public sealed class LeagueSimulation
    {
        private static LeagueSimulation? _instance;
        private static readonly object _lock = new object();

        public string GameMode { get; set; } = "Simulation";
        public string MatchQuarter { get; set; } = "1st Quarter";

        private LeagueSimulation() { }

        public static LeagueSimulation Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LeagueSimulation();
                    }
                    return _instance;
                }
            }
        }

        public void PrintLeagueStatus()
        {
            Console.WriteLine($"[LEAGUE STATUS] Period: {MatchQuarter} | Game Mode: {GameMode}");
        }
    }
}
