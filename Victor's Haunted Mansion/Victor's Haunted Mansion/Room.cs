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
                descriptionText += $"There is a {item.Name} in the room. ";
            }
            return descriptionText;
        }

        public void AddExit(Exit exit, string direction)
        {
            ExitHolder holder = new ExitHolder(exit, direction);  
            exits.Add(holder);
        }

        public bool UseItemOnExit(Item item, string exit)
        {
            for (int i = 0; i < exits.Count; i++)
            {
                if (exits[i].Name == exit)
                {
                    if (exits[i].GetExit().UseItemOn(item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int Go(string direction)
        {
            foreach (ExitHolder exit in exits)
            {
                if (exit.GetDirection() == direction && !exit.GetExit().IsLocked())
                {
                    return exit.GetExit().RoomNumber;
                }
            }
            return -1;
        }
        public string InspectRoom(string name)
        {
            foreach (var item in itemList)
            {
                if (item.Name == name)
                {
                    return item.ItemInformation;
                }
            }
            foreach (var exit in exits)
            {
                if (exit.Name == name)
                {
                    return exit.GetExit().GetInformation();
                }
            }
            return null;
        }

        public class ExitHolder
        {
            
            private Exit exit;
            private string direction;

            public string Name
            {
                get { return exit.Name; }
            }

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
            

            public Exit GetExit()
            {
                return exit;
            }

            public string GetDirection()
            {
                return direction;
            }
        }
    }
}
