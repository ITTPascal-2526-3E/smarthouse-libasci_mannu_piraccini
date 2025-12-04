using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class DoorTest
    {
        // Test 1: Door starts closed
        [Fact]
        public void Door_initiallyClosed_IsClosed()
        {
            var door = new Door();
            Assert.False(door.IsOpen());
            Assert.False(door.IsLocked());
        }

        // Test 2: Open a closed unlocked door
        [Fact]
        public void OpenOrClose_ClosedUnlockedDoor_OpensDoor()
        {
            var door = new Door();
            door.OpenOrClose();
            Assert.True(door.IsOpen());
        }

        // Test 3: Close an open door
        [Fact]
        public void OpenOrClose_OpenDoor_ClosesDoor()
        {
            var door = new Door();
            door.OpenOrClose(); // open
            door.OpenOrClose(); // close
            Assert.False(door.IsOpen());
        }

        // Test 4: Open a locked door throws exception
        [Fact]
        public void OpenOrClose_LockedDoor_ThrowsException()
        {
            var door = new Door();
            door.LockOrUnlock(); // lock
            Assert.Throws<InvalidOperationException>(() => door.OpenOrClose());
        }

        // Test 5: Lock a closed door
        [Fact]
        public void LockOrUnlock_ClosedDoor_LocksDoor()
        {
            var door = new Door();
            door.LockOrUnlock();
            Assert.True(door.IsLocked());
        }

        // Test 6: Lock an open door throws exception
        [Fact]
        public void LockOrUnlock_OpenDoor_ThrowsException()
        {
            var door = new Door();
            door.OpenOrClose(); // open
            Assert.Throws<InvalidOperationException>(() => door.LockOrUnlock());
        }

        // Test 7: Unlock a locked door
        [Fact]
        public void LockOrUnlock_LockedDoor_UnlocksDoor()
        {
            var door = new Door();
            door.LockOrUnlock(); // lock
            door.LockOrUnlock(); // unlock
            Assert.False(door.IsLocked());
        }
    }
}

