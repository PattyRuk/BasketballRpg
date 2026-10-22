using BasketballRpg.Adaptors;
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
            string positionReal = position.ToLower().Trim();

            if (positionReal.StartsWith("mascot"))
            {
                string[] components = positionReal.Split('-');
                string color = components.Length > 1 ? components[1].Trim() : "Red";
                color = char.ToUpper(color[0]) + color.Substring(1).ToLower();
                return new SplorgAdaptor(new Splorg(name, color));
            }
            return positionReal switch
            {
                "guard" => new Guard(name),
                "forward" => new Forward(name),
                "center" => new Center(name),
                _ => throw new ArgumentException("Provided position/player not found. Valid inputs are: Guard, Forward, Center, or a Mascot.")
            };
        }
    }
}
