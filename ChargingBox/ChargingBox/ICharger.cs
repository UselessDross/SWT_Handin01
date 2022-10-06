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

    public interface ICharger
    {
        event System.EventHandler StateChanged;

        ChargerState State { get; set; }
        bool IsConnected { get; set; }

        void Start();
        void Stop();
    }
}