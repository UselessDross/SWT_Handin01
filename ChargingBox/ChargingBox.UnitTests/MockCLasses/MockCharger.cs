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
            StateChanged.Invoke(this, new ChargerStateChangedEventArgs());
            State = ChargerState.Idle;

        }

        public void Stop()
        {
            State = ChargerState.FullyCharged;
        }

        public void changeIsConnected(bool newState)
        {
            IsConnected = newState;
        }

        public void OnMockStateCHange(ChargerStateChangedEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }

        public void changeStateEvent(ChargerState state_, ChargerState after_, ChargerState before_)
        {
            State = state_;
            ChargerStateChangedEventArgs eventArg = new ChargerStateChangedEventArgs();
            eventArg.After = after_;
            eventArg.Before = before_;
            StateChanged.Invoke(this, eventArg);
        }
    }
}
