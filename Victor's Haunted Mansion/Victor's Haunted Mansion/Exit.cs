using System;
using System.Collections.Generic;
using System.Linq;
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
       

        
        public Exit(string name, bool locked, string informationLocked, string informationOpen, string unlockItem)
        {
            Name = name;
            isLocked = locked;
            this.informationLocked = informationLocked;
            this.informationOpen = informationOpen;
            this.unlockItem = unlockItem;        
        }
        public void UseItemOn(Item item)
        {
            if (unlockItem == item.Name)
            {
                isLocked = true;
            }
        }
        public string GetInformation()
        {
            if (isLocked)
            {
                return informationLocked;
            }
            return informationOpen;
        }
    }

    
}
