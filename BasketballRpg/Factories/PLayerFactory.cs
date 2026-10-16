using BasketballRpg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Factories
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(string position, string name)
        {
            return position.ToLower() switch
            {
                "guard" => new Guard(name),
                "forward" => new Forward(name),
                "center" => new Center(name),
                _ => throw new ArgumentException("Provided position mismatch. Valid inputs are: Guard, Forward, Center.")
            };
        }
    }
}
