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
        public int InRoom { get; set; } //Vilket rum player befinner sig i

        public Player(string name)
        {
            Name = name;
        }

        //Lägg till item i inventory
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        //Ta bort ett item ur inventory, och retunera det itemet
        public Item DropItem(string itemName)
        {
            Item item = null;

            //Kolla om item finns i inventory. Om item finns spara i item och ta bort ur inventory
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Name == itemName)
                {
                    item = inventory[i];
                    inventory.RemoveAt(i);
                    break;
                }
            }

            return item;
        }

        //Få item ur inventory utan att ta bort det ur inventory listan
        public Item GetItem(string itemName)
        {
            foreach (var item in inventory)
            {
                if (item.Name == itemName)
                {
                    return item;
                }
            }
            return null;
        }

        //Försöker kommbinera två item. Retunerar true nytt item skapats
        public bool CombinedItems(string item1, string item2)
        {
            //Om player har båda item's i inventory
            if (InventoryCountainsItem(item1) && InventoryCountainsItem(item2))
            {
                //Försök att skapa nytt item
                Item item = Item.CraftItem(item1, item2);

                //Om nytt item skapades
                if (item != null)
                {
                    //Ta bort använda item
                    //DropItem(item1);
                    DropItem(item2);

                    //Och lägg till det nya
                    inventory.Add(item);

                    //Retunera att nytt item skapades
                    return true;
                }

            }

            //Retunera att inget nytt item har skapats
            return false;
        }

        //Kollar om item finns i inventory
        public bool InventoryCountainsItem(string item)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Name == item)
                    return true; //Item finns i inventory
            }

            return false; //Item finns inte i inventory
        }

        //Information om vad som finns i inventory. Retuneras som en textsträng
        public string InventoryPrint()
        {
            string text = "Inventory List: \n";

            if (inventory.Count == 0)
            {
                text += "Your inventory is empty";
            }
            else
            {
                //lägg till information om alla items som finns i inventory
                foreach (var item in inventory)
                {
                    text += item.Name + "\n";
                }

            }

            //retunera information om inventory
            return text;
        }

        //Få information ett item i inventory
        public string InspectInventory(string itemName)
        {
            foreach (var item in inventory)
            {
                if (item.Name == itemName)
                {
                    return item.ItemInformation; //Retunera info om item
                }
            }

            return null; //Item fanns inte i inventory, ingen text
        }
    }
}