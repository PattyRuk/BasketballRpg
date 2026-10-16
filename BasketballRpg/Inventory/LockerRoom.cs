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

        public void DisplayItems()
        {
            Console.WriteLine("--- Locker Room Full Items View ---");
            if (_lockerRoomItems.Count == 0)
            {
                Console.WriteLine("(Inventory contains 0 items)");
                return;
            }
            foreach (var item in _lockerRoomItems)
            {
                Console.WriteLine($"[*] {item.ItemName} | Category: {item.Category}");
            }
        }

        public void DisplayItemByCategory(string selectedCategory)
        {
            Console.WriteLine($"--- Category Search - View: [{selectedCategory}] ---");
            bool matchFound = false;

            foreach (var item in _lockerRoomItems)
            {
                if (item.Category.Equals(selectedCategory, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($" -> Match: {item.ItemName}");
                    matchFound = true;
                }
            }

            if (!matchFound)
            {
                Console.WriteLine($"[Zero Records] No items fit category '{selectedCategory}'.");
            }
        }
    }
}
