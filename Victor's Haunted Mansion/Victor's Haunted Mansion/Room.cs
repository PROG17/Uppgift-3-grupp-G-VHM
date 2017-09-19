using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Victor_s_Haunted_Mansion
{
    class Room
    {
        public bool EndPoint { get; private set; }
        private List<Item> itemList = new List<Item>();
        private string description;
        private List<ExitHolder> exits = new List<ExitHolder>();
        

        public Room(string description, bool endPoint)
        {
            this.description = description;
            EndPoint = endPoint;
        }

        public Item GetItem(string itemName)
        {
            Item item = null;

            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].Name == itemName)
                {
                    item = itemList[i];
                    itemList.RemoveAt(i);
                    break;
                }
            }
            
            return item;
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        public string GetDescription()
        {
            string descriptionText = $"{description} ";
            foreach (var exit in exits)
            {
                descriptionText += $"{exit.GetInformation()} ";
            }
            foreach (var item in itemList)
            {
                descriptionText += $"{item.Name} ";
            }
            return descriptionText;
        }

        public void AddExit(Exit exit, string direction)
        {
            ExitHolder holder = new ExitHolder(exit, direction);  
            exits.Add(holder);
        }

        public class ExitHolder
        {
            
            private Exit exit;
            private string direction;

            public ExitHolder(Exit exit, string direction)
            {
                this.exit = exit;
                this.direction = direction;
            }

            public string GetInformation()
            {
                string information = "In the " + direction + " there is a " + exit.Name + ".";
                return information;
            }
        }
    }
}
