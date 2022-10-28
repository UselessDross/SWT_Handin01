using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingBox
{
    public enum ChargingBoxState
    {
        Available,
        Locked,
        Unlocked,
        Error
    }

    public class ChargingBox
    {
        public IDoor Door { get; set; }
        public ICharger Charger { get; set; }
        public IKeyReader KeyReader { get; set; }
        public IDisplay Display { get; set; }
        public ILogger Logger { get; set; }

        public ChargingBoxState State { get; set; }

        private object? _key;

        public ChargingBox(IDoor door, ICharger charger, IKeyReader keyReader, IDisplay display, ILogger logger)
        {
            // Charging Box variables
            State = ChargingBoxState.Available;
            _key = null;
            // Door
            Door = door;
            if (Door.IsLocked) Door.Unlock();
            // Charger
            Charger = charger;
            switch (Charger.State)
            {
                case ChargerState.Charging:
                case ChargerState.FullyCharged:
                    {
                        Charger.Stop();
                    }
                    break;
                case ChargerState.Error: State = ChargingBoxState.Error; break;
                default: break;
            }
            charger.StateChanged += HandleChargerStateChanged;
            // KeyReader
            KeyReader = keyReader;
            KeyReader.KeyRead += HandleKeyRead;
            // Display
            Display = display;
            UpdateDisplay();
            // Logger
            Logger = logger;
        }

        private void HandleKeyRead(object? sender, KeyReaderKeyReadEventArgs args)
        {
            switch (State)
            {
                default: break;
                case ChargingBoxState.Available: Trylock(args.Key);
                    break;
                case ChargingBoxState.Locked: TryUnlock(args.Key);
                    break;
            }
        }
        private bool Trylock(object? key)
        {
            if (State != ChargingBoxState.Available) return false;
            if (Door.IsOpen) return false;
            if (Charger.IsConnected is false) return false;

            State = ChargingBoxState.Locked;
            Door.Lock();
            _key = key;

            Charger.Start();

            Logger.LogLock(true, key);

            UpdateDisplay();
            return true;
        }
        private bool TryUnlock(object? key)
        {
            if ((_key?.Equals(key) ?? key is null) is false) return false;

            Charger.Stop();

            Door.Unlock();
            State = ChargingBoxState.Available;
            _key = null;

            Logger.LogLock(false, key);

            UpdateDisplay();
            return true;
        }

        private void HandleChargerStateChanged(object? sender, ChargerStateChangedEventArgs args)
        {
            if (args.After == ChargerState.Error)
            {
                State = ChargingBoxState.Error;
            }

            switch (State)
            {
                case ChargingBoxState.Available:
                case ChargingBoxState.Locked:
                    break;
                case ChargingBoxState.Unlocked:
                    {
                        if (args.After == ChargerState.Idle)
                        {
                            State = ChargingBoxState.Available;
                        }
                    }
                    break;
                default:
                    State = ChargingBoxState.Error;
                    break;
            }

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            string message = State switch
            {
                ChargingBoxState.Available => "Available",
                ChargingBoxState.Locked => Charger.State switch
                {
                    ChargerState.Idle => "",
                    ChargerState.Charging => "Charging...",
                    ChargerState.FullyCharged => "Phone fully charged",
                    _ => "Error!",
                },
                ChargingBoxState.Unlocked => "Remember your phone!",
                _ => "Error!",
            };

            Display.Display(message);
        }
    }
}