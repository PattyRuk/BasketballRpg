using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballRpg.Entities;

namespace BasketballRpg.Adaptors
{
    public class SplorgAdaptor : Player
    {
        private readonly Splorg _legacySplorg;
        public  string Name => $"{_legacySplorg.Name} ({_legacySplorg.Color} Mascot)";
        public int Health => (int)(_legacySplorg.BubbleMatterRemaining * 100);
        public int Defense => _legacySplorg.BubbleDurability * 3;
        public int Speed => _legacySplorg.Speed * 3;
        public int Strength => _legacySplorg.Luck * 3;
        public int Intellect => _legacySplorg.Smarts * 3;
        public int Agility => _legacySplorg.Finesse * 3;

       
        
    }
}
