using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor_s_Haunted_Mansion
{
    class Player
    {
        List<Item> inventory = new List<Item>();
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }
        public Item DropItem(string itemName)
        {
            Item item = null;
            for (int i = 0; i < inventory.Count; i++)
            {
                if ( inventory[i].Name == itemName)
                {
                    item = inventory[i];
                    inventory.RemoveAt(i);
                    break;
                }
            }
            return item;
        }
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }
        public string CombinedItems(string item1, string item2)
        {
            if (InventoryCountainsItem(item1) && InventoryCountainsItem(item2))
            {
                Item item = Item.CraftItem(item1, item2);
                if(item != null){
                    DropItem(item1);
                    DropItem(item2);
                    inventory.Add(item);
                    return "Successfully created a " + item.Name + ".";
                }
                else
                {
                    return "The items could not be combined.";
                }
            }
            else
            {
                return "The inventory does not contain both items.";
            }
            
        }

        public bool InventoryCountainsItem(string item)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Name == item)
                    return true;
            }
            return false;
        }

        public string InventoryPrint()
        {
            string text = "Inventory List: \n";
            foreach (var item in inventory)
            {
                text += item.Name + "\n";
            }
            return text;
        }
    }
}