using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.Implementation
{
    public class ChargerControl : ICharger
    {

        private void CharHelperMethod(ChargerState state_)
        {
            StateChanged += (s, args) =>
            {
                State = state_;
            };
            OnStateCHange();
        }

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
            int phoneTemp = 2323;                                                 // just som numbers for the time while working on this.
            if(phoneTemp == 0 || IsConnected == false) {                          // 0mA 
                CharHelperMethod(ChargerState.Idle);
            }
            else if(phoneTemp > 0 || phoneTemp <= 5 && IsConnected == true) {     // 0mA < ladestrøm <= 5mA (NOT 500mA)
                CharHelperMethod(ChargerState.Charging);
            }
            else if (phoneTemp > 5 || phoneTemp <= 500 && IsConnected == true) {  // 5mA < ladestrøm <= 500mA
                CharHelperMethod(ChargerState.FullyCharged);
            }
            else if (phoneTemp > 500) {                                           // ladestrøm > 500mA
                CharHelperMethod(ChargerState.Error);
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
