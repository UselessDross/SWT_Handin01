using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingBox
{
    public class DoorOpenedEventArgs { }
    public class DoorClosedEventArgs { }
    public class DoorLockedEventArgs { }
    public class DoorUnlockedEventArgs { }

    public interface IDoor
    {
        event System.EventHandler<DoorOpenedEventArgs>? Opened;
        event System.EventHandler<DoorClosedEventArgs>? Closed;
        event System.EventHandler<DoorLockedEventArgs>? Locked;
        event System.EventHandler<DoorUnlockedEventArgs>? Unlocked;

        bool IsOpen { get; }
        bool IsLocked { get; }

        void Unlock();
        void Lock();
    }
}