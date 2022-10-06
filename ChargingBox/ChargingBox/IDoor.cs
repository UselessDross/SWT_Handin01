using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingBox
{
    public interface IDoor
    {
        event System.EventHandler Opened;
        event System.EventHandler Closed;
        event System.EventHandler Locked;
        event System.EventHandler Unlocked;

        bool IsOpen { get; set; }
        bool IsLocked { get; set; }

        void Open();
        void Close();
        void Unlock();
        void Lock();
    }
}