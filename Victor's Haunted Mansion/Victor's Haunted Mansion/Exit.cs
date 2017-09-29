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
        public bool IsLocked { get; private set; } //true om exit är låst
        private string informationLocked; //detaljerad text om låst exit
        private string informationOpen; //detaljerad text om upplåst exit
        private string unlockItem; //vad som kan låsa upp exit
        public int RoomNumber { get; private set; } //vilket rum leder den till

        /*<exit's namn, exit leder till rum, true om exit är låst, medelandet som ska visas om exit är låst,
         * medelandet som ska visas om dörren är öppen, vilket item som kan låsa upp dörren */
        public Exit(string name, int roomNumber, bool isLocked, string informationLocked, string informationOpen, string unlockItem)
        {
            Name = name;
            IsLocked = isLocked;
            this.informationLocked = informationLocked;
            this.informationOpen = informationOpen;
            this.unlockItem = unlockItem;
            this.RoomNumber = roomNumber;
        }

        //Kan item användas på exit
        public bool UseItemOn(Item item)
        {
            if (unlockItem == item.Name)
            {
                IsLocked = false;
                return true;
            }
            return false;
        }

        //Retunerar information om exit, vad som retuneras beror på om exit är låst eller öppen
        public string GetInformation()
        {
            if (IsLocked)
            {
                return informationLocked;
            }
            return informationOpen;
        }

    }
}
