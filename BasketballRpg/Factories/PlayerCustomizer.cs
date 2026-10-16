using BasketballRpg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Factories
{
    public class PlayerCustomizer
    {
        private readonly Player _player;

        public PlayerCustomizer(Player basePlayer)
        {
            _player = basePlayer;
        }

        public PlayerCustomizer SetJerseyNumber(int number)
        {
            if (number >= 0 && number <= 99)
            {
                _player.JerseyNumber = number;
            }
            return this;
        }

        public PlayerCustomizer SetHometown(string location)
        {
            if (!string.IsNullOrWhiteSpace(location))
            {
                _player.Hometown = location;
            }
            return this;
        }

        public Player Build()
        {
            return _player;
        }
    }
}
