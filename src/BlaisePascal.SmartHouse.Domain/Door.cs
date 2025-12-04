using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Door
    {
        Guid id_door = Guid.NewGuid();
        public bool isOpen = false;
        public bool isLocked = false;

        // Open or close the door
        public void OpenOrClose()
        {
            if (isLocked && !isOpen)
            {
                throw new InvalidOperationException($"The door is locked and cannot be opened.");
            }

            isOpen = !isOpen;
        }

        // Lock or unlock the door
        public void LockOrUnlock()
        {
            if (isOpen && !isLocked)
            {
                throw new InvalidOperationException($"Cannot lock the door while it is open.");
            }

            isLocked = !isLocked;
        }

        // Status methods
        public bool IsOpen()
        {
            return isOpen;
        }

        public bool IsLocked()
        {
            return isLocked;
        }
    }
}


