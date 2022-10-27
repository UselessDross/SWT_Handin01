using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.UnitTests.MockCLasses
{
    internal class MockDoor : IDoor
    {
        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }

        public event EventHandler<DoorOpenedEventArgs>? Opened;
        public event EventHandler<DoorClosedEventArgs>? Closed;
        public event EventHandler<DoorLockedEventArgs>? Locked;
        public event EventHandler<DoorUnlockedEventArgs>? Unlocked;

        public void Close()
        {
            IsOpen = false;
        }

        public void Lock()
        {
            IsLocked = true;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }
    }
}
