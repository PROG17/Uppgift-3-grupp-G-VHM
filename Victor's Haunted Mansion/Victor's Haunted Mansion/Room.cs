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
        private List<Item> itemList = new List<Item>(); //Alla items som finns i rummet
        private string description; //Rumsbeskrivning
        private List<ExitHolder> exits = new List<ExitHolder>(); //Lista som håller koll på dörrarnas position relativt rummet
        
        public Room(string description, bool endPoint)
        {
            this.description = description;
            EndPoint = endPoint;
        }

        //Försök att ta ett item från rummet
        public Item GetItem(string itemName)
        {
            Item item = null;

            for (int i = 0; i < itemList.Count; i++)
            {
                //Om itemet finns i rummet
                if (itemList[i].Name == itemName)
                {
                    //Spara item i item och ta bort ifrån rummslistan
                    item = itemList[i];
                    itemList.RemoveAt(i);
                    break;
                }
            }
            
            return item; 
        }

        //Lägg till item till rummet
        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        //Få en beskrivning av rummet
        public string GetDescription()
        {
            //Lägg till rummets generella beskrivning
            string descriptionText = $"{description} ";

            //Lägg till information om alla exits och deras position
            foreach (var exit in exits)
            {
                descriptionText += $"{exit.GetInformation()} ";
            }

            //Lägg till information om alla item i rummet
            foreach (var item in itemList)
            {
                descriptionText += $"There is a {item.Name} in the room. ";
            }

            //Retunera beskrivning
            return descriptionText;
        }

        //Lägg till exit i rummet
        public void AddExit(Exit exit, string direction)
        {
            ExitHolder holder = new ExitHolder(exit, direction);  
            exits.Add(holder);
        }

        //Försök att använda ett item på en exit
        public bool UseItemOnExit(Item item, string exit)
        {
            //Lopa igenom alla exitholders
            for (int i = 0; i < exits.Count; i++)
            {
                //Om det är rätt exit
                if (exits[i].Name == exit)
                {
                    //Försök att använda item på exit
                    if (exits[i].GetExit().UseItemOn(item))
                    {
                        return true; //Exit låstes upp
                    }
                }
            }

            return false; //Ingen Exit låstes upp
        }

        //Försök att gå ut ur rummet
        public int Go(string direction)
        {
            //Lopa igenom alla exit holders
            foreach (ExitHolder exit in exits)
            {
                //Om det finns en dörr i angiven riktning och dörren är upplåst
                if (exit.GetDirection() == direction && !exit.GetExit().IsLocked)
                {
                    //Retunera vilket rum dörren leder till
                    return exit.GetExit().RoomNumber;
                }
            }
            
            return -1; //Det gick inte att gå åt "direction"
        }

        //Försök att inspectera item eller exit i rummet
        public string InspectRoom(string name)
        {
            //Kolla om name matchar ett item i rummet
            foreach (var item in itemList)
            {
                if (item.Name == name)
                {
                    return item.ItemInformation; //Retunera detaljerad beskrivning om rummet
                }
            }

            //Kolla om name machar en exitholder i rummet
            foreach (var exit in exits)
            {
                if (exit.Name == name)
                {
                    return exit.GetExit().GetInformation(); //Få detaljerat information om exit i exitholder
                }
            }

            return null; //Name matchade inget i rummet
        }


        private class ExitHolder //Håller en exit på en specifik plats
        {
            private Exit exit; //Sparar en exit
            private string direction; //Och vart exit är placerat

            public string Name
            {
                get { return exit.Name; }
            }

            public ExitHolder(Exit exit, string direction)
            {
                this.exit = exit;
                this.direction = direction;
            }

            //Få information om var exit är placerad
            public string GetInformation()
            {
                string information = "In the " + direction + " there is a " + exit.Name + ".";
                return information;
            }
            
            //Få exit
            public Exit GetExit()
            {
                return exit;
            }

            //Få vilket rikting dörren är placerad
            public string GetDirection()
            {
                return direction;
            }
        }
    }
}
