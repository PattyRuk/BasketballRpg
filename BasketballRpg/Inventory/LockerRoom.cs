using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Inventory
{
    public class LockerRoom
    {
        private readonly List<InventoryItem> _lockerRoomItems = new List<InventoryItem>();

        public void GetItem(string name, string category)
        {
            InventoryItem newItem = new InventoryItem(name, category);
            _lockerRoomItems.Add(newItem);
            Console.WriteLine($"[Locker Facility] Tracked item '{name}' inside the '{category}' cluster.");
        }




    }
}
