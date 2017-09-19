using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor_s_Haunted_Mansion
{
    class Item
    {
        public string Name { get; private set; }
        public string ItemInformation { get; private set; }

        public Item(string name, string itemInformation)
        {
            Name = name;
            ItemInformation = itemInformation;
        }
        public static Item CraftItem(string item1, string item2)
        {
            if ((item1 == "stick" && item2 == "matches") || (item2 == "stick" && item1 == "matches"))
            {
                Item item = new Item("torch", "A fiercely burning torch.");
                return item;
            }
            return null;
        }
    }
}
