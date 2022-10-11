using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.Implementation
{
    public class ChargerControl : ICharger
    {
        public ChargerState State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsConnected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public event EventHandler<ChargerStateChangedEventArgs> StateChanged;

        public void OnStateCHange()
        {
            ChargerStateChangedEventArgs newArg = new ChargerStateChangedEventArgs();
            newArg.Before = State;
            StateChanged.Invoke(this, newArg);
        }


        public void Start()
        {
            int phoneTemp = 2323; // just som numbers for the time while working on this.
            if(phoneTemp == 0 || IsConnected == false) 
            {
                StateChanged += (s, args) =>
                {
                    State = ChargerState.Idle;
                };
                OnStateCHange();
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }


        // thanks to this video. 
        //https://www.youtube.com/watch?v=gYC-9PUGwDI


    }
}
