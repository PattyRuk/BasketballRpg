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

        private const string DefaultStyle = "Simulation";
        private const string DefaultPeriod = "1st Quarter";

        public string GameStyle { get; set; } = DefaultStyle;
        public string MatchQuarter { get; set; } = DefaultPeriod;

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
            Console.WriteLine($"[LEAGUE STATUS] Period: {MatchQuarter} | Game Mode: {GameStyle}");
        }
    }
}
