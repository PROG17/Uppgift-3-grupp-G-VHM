using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Victor_s_Haunted_Mansion
{
    class Exit
    {
        public string Name { get; private set; }
        private bool isLocked;
        private string informationLocked;
        private string informationOpen;
        private string unlockItem;
        public int RoomNumber { get; private set; }

        
        public Exit(string name, int roomNumber, bool locked, string informationLocked, string informationOpen, string unlockItem)
        {
            Name = name;
            isLocked = locked;
            this.informationLocked = informationLocked;
            this.informationOpen = informationOpen;
            this.unlockItem = unlockItem;
            this.RoomNumber = roomNumber;
        }
        public bool UseItemOn(Item item)
        {
            if (unlockItem == item.Name)
            {
                isLocked = false;
                return true;
            }
            return false;
        }
        public string GetInformation()
        {
            if (isLocked)
            {
                return informationLocked;
            }
            return informationOpen;
        }

        public bool IsLocked()
        {
            return isLocked;
        }
    }

    
}
