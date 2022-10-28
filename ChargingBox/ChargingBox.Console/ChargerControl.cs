using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.ConsoleImp
{
    public class ChargerControl : ICharger
    {
        public event EventHandler<ChargerStateChangedEventArgs>? StateChanged;
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
                _chargerState = value;
                newArg.After = _chargerState; 
                StateChanged?.Invoke(this, newArg);
            } 
        }
    

        private  int ChargingMethod(int  Phone)
        {
            return  Phone + 1;
        }


        public void Start()
        {
            if (IsConnected == true)
            {


                int phoneTemp = 0;
                State = ChargerState.Charging; // for some reason it seems whenever state in charingCOntorler class changes the stahe of the box gets printed out.
                while (State == ChargerState.Charging)
                {
                    phoneTemp = ChargingMethod( phoneTemp);
                    if ((phoneTemp > 5 && phoneTemp <= 500) && IsConnected == true)
                    {
                        State = ChargerState.FullyCharged;
                    }//avaliable gets printed around here
                }
            }
        }

        public void Stop()
        {
            //IsConnected = false;
            State = ChargerState.Idle;
        }



    }
}
