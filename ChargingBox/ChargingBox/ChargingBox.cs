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
        public IDoor Door;
        public ICharger Charger;
        public IKeyReader KeyReader;
        public IDisplay Display;
        public ILogger Logger;

        public ChargingBoxState State;
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
            _key = key;

            Charger.Start();

            Logger.LogLock(true, key, "LogFile.txt");

            UpdateDisplay();
            return true;
        }
        private bool TryUnlock(object? key)
        {
            bool keyMatch;
            if (_key is null) keyMatch = key is null;
            else keyMatch = _key.Equals(key);
            if (keyMatch is false) return false;

            Charger.Stop();

            State = ChargingBoxState.Available;
            _key = null;

            Logger.LogLock(false, key, "LogFile.txt");

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
            string message;
            switch (State)
            {
                case ChargingBoxState.Available: message = "Available";
                    break;
                case ChargingBoxState.Locked:
                    switch (Charger.State)
                    {
                        case ChargerState.Idle: message = "";
                            break;
                        case ChargerState.Charging: message = "Charging...";
                            break;
                        case ChargerState.FullyCharged: message = "Phone fully charged";
                            break;
                        default: message = "Error!";
                            break;
                    }
                    break;
                case ChargingBoxState.Unlocked: message = "Remember your phone!";
                    break;
                default: message = "Error!";
                    break;
            }

            Display.Display(message);
        }
    }
}