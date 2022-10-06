using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingBox
{
    public enum ChargerState
    {
        Idle,
        Charging,
        FullyCharged,
        Error
    }

    public class ChargerStateChangedEventArgs
    {
        public ChargerState Before;
        public ChargerState After;
    }

    public interface ICharger
    {
        event System.EventHandler<ChargerStateChangedEventArgs> StateChanged;

        ChargerState State { get; set; }
        bool IsConnected { get; set; }

        void Start();
        void Stop();
    }
}