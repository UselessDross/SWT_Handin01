using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.ConsoleImp
{
    public class ConsoleDoor : IDoor
    {
        public event EventHandler<DoorOpenedEventArgs>? Opened;
        public event EventHandler<DoorClosedEventArgs>? Closed;
        public event EventHandler<DoorLockedEventArgs>? Locked;
        public event EventHandler<DoorUnlockedEventArgs>? Unlocked;

        public bool IsOpen => _isOpen;
        public bool IsLocked => _isLocked;

        private bool _isOpen;
        private bool _isLocked;

        public ConsoleDoor(bool isOpen, bool isLocked)
        {
            if (isOpen && isLocked) throw new ArgumentException("Tried creating a door that is both locked and open");

            _isOpen = isOpen;
            _isLocked = isLocked;
        }

        public void Open()
        {
            if (IsOpen) throw new InvalidOperationException("Tried opening a door that is already open");
            if (IsLocked) throw new InvalidOperationException("Tried opening a locked door");

            _isOpen = true;
            Opened?.Invoke(this, new());
            PrintState();
        }
        public void Close()
        {
            if (IsOpen is false) throw new InvalidOperationException("Tried closing a door that is already closed");

            _isOpen = false;
            Closed?.Invoke(this, new());
            PrintState();
        }
        public void Unlock()
        {
            if (IsLocked is false) throw new InvalidOperationException("Tried unlocking a door that is already unlocked");

            _isLocked = false;
            Unlocked?.Invoke(this, new());
            PrintState();
        }
        public void Lock()
        {
            if (IsOpen) throw new InvalidOperationException("Tried locking a door that is open");
            if (IsLocked) throw new InvalidOperationException("Tried locking a door that is already locked");

            _isLocked = true;
            Locked?.Invoke(this, new());
            PrintState();
        }

        public string GetState() =>
            "Door is " +
            (IsLocked ? "locked" : "unlocked") +
            " and " +
            (IsOpen ? "open" : "closed");
        private void PrintState() => Console.WriteLine(GetState());
    }
}
