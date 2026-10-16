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
        protected readonly Player badgedPlayer;

        public virtual string Name => badgedPlayer.Name;
        public virtual int Health => badgedPlayer.Health;
        public virtual int Defense => badgedPlayer.Defense;
        public virtual int Speed => badgedPlayer.Speed;
        public virtual int Strength => badgedPlayer.Strength;
        public virtual int Intellect => badgedPlayer.Intellect;
        public virtual int Agility => badgedPlayer.Agility;

        public virtual int JerseyNumber
        {
            get => badgedPlayer.JerseyNumber;
            set => badgedPlayer.JerseyNumber = value;
        }
        public virtual string Hometown
        {
            get => badgedPlayer.Hometown;
            set => badgedPlayer.Hometown = value;
        }

        protected BadgeDecorator(Player player) => badgedPlayer = player;

        public virtual void Act() => badgedPlayer.Act();
        public virtual void Speak() => badgedPlayer.Speak();
        public virtual void PrintDetails() => badgedPlayer.PrintDetails();
    }
}
