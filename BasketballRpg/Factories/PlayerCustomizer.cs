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


    }
}
