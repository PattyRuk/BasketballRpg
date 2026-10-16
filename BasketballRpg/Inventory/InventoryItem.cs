using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRpg.Inventory
{
    public class InventoryItem
    {
        public string ItemName { get; }
        public string Category { get; } 

        public InventoryItem(string name, string category)
        {
            ItemName = name;
            Category = category;
        }
    }
}
