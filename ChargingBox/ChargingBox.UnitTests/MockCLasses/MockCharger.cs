using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.UnitTests.MockCLasses
{
    internal class MockCharger : ICharger
    {
        public ChargerState State { get; set; }
        public bool IsConnected { get; set; }

        public event EventHandler<ChargerStateChangedEventArgs> StateChanged;

        public void Start()
        {
            Console.WriteLine("charging");
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
