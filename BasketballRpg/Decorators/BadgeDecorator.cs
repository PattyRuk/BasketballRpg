using BasketballRpg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Decorators
{
    public abstract class BadgeDecorator : Player
    {
        protected readonly Player WrappedPlayer;

        public virtual string Name => WrappedPlayer.Name;
        public virtual int Health => WrappedPlayer.Health;
        public virtual int Defense => WrappedPlayer.Defense;
        public virtual int Speed => WrappedPlayer.Speed;
        public virtual int Strength => WrappedPlayer.Strength;
        public virtual int Intellect => WrappedPlayer.Intellect;
        public virtual int Agility => WrappedPlayer.Agility;


    }
}
