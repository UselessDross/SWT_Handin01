﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.Implementation
{
    public class ChargerControl : ICharger
    {
        public event EventHandler<ChargerStateChangedEventArgs> StateChanged;
        private ChargerState _chargerState;
        public bool IsConnected { get ; set ; }

        public ChargerState State {
            get
            {
                return _chargerState;
            } 
            set
            {
                ChargerStateChangedEventArgs newArg = new ChargerStateChangedEventArgs();
                newArg.Before = _chargerState;
                newArg.After = _chargerState; 
                _chargerState = value;
                StateChanged?.Invoke(this, newArg);
            } 
        }
    

        private int ChargingMethod(int Phone)
        {
            return Phone + 1;
        }


        public void Start()
        {
            int phoneTemp = 0;
            State = ChargerState.Charging;
            while ( State == ChargerState.Charging)
            {
                ChargingMethod(phoneTemp);
                if (phoneTemp > 5 || phoneTemp <= 500 && IsConnected == true)
                {
                    State = ChargerState.FullyCharged;
                }
                else if (phoneTemp > 500 || IsConnected == false)
                {
                    State = ChargerState.Error;
                }
            }
        }

        public void Stop()
        {
            IsConnected = false;
            State = ChargerState.Idle;
        }


        // thanks to this video. 
        //https://www.youtube.com/watch?v=gYC-9PUGwDI


    }
}