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

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }


        public void OnStateChanged() 
        {
            throw new NotImplementedException(); 
        }



    }
}
