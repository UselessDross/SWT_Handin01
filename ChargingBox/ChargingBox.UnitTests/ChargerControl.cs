using ChargingBox.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.UnitTests
{
    public class ChargerControlUnitTests
    {
        ICharger _charger;
        List<(object? sender, ChargerStateChangedEventArgs args)> _receivedArgs;

        [SetUp]
        public void Setup()
        {
            _charger = new ChargerControl();

            _receivedArgs = new();
            _charger.StateChanged += (object? sender, ChargerStateChangedEventArgs args) =>
            {
                _receivedArgs.Add(new(sender, args));
            };
        }

        private void Start_Setup()
        {
            _charger.IsConnected = true;
            _charger.Start();
        }
        [Test]
        public void Start_IsConnected()
        {
            Start_Setup();

            Assert.That(_charger.IsConnected, Is.True);
        }
        [Test]
        public void Start_State()
        {

            int stateChangeCount = 0;
            _charger.StateChanged += (object? sender, ChargerStateChangedEventArgs args) =>
            {
                ++stateChangeCount;

                Assert.That(stateChangeCount, Is.InRange(1, 2));
                ChargerState expected = stateChangeCount switch
                {
                    1 => ChargerState.Charging,
                    2 => ChargerState.FullyCharged,
                    _ => throw new IndexOutOfRangeException(),
                };

                Assert.That(_charger.State, Is.EqualTo(expected));
            };

            Start_Setup();
        }
        [Test]
        public void Start_StateChanged_Count()
        {
            Start_Setup();

            Assert.That(_receivedArgs, Has.Count.EqualTo(2));
        }
        [Test]
        public void Start_StateChanged_Sender([Range(1, 2)] int caseNumber)
        {
            Start_Setup();

            Assert.That(_receivedArgs, Has.Count.GreaterThanOrEqualTo(caseNumber));
            Assert.That(_receivedArgs[caseNumber - 1].sender, Is.EqualTo(_charger));
        }
        [Test]
        public void Start_StateChanged_Before([Range(1, 2)] int caseNumber)
        {
            Start_Setup();

            ChargerState expected = caseNumber switch
            {
                1 => ChargerState.Idle,
                2 => ChargerState.Charging,
                _ => throw new ArgumentOutOfRangeException(nameof(caseNumber)),
            };

            Assert.That(_receivedArgs, Has.Count.GreaterThanOrEqualTo(caseNumber));
            Assert.That(_receivedArgs[caseNumber - 1].args.Before, Is.EqualTo(expected));
        }
        [Test]
        public void Start_StateChanged_After([Range(1, 2)] int caseNumber)
        {
            Start_Setup();

            ChargerState expected = caseNumber switch
            {
                1 => ChargerState.Charging,
                2 => ChargerState.FullyCharged,
                _ => throw new ArgumentOutOfRangeException(nameof(caseNumber)),
            };

            Assert.That(_receivedArgs, Has.Count.GreaterThanOrEqualTo(caseNumber));
            Assert.That(_receivedArgs[caseNumber - 1].args.After, Is.EqualTo(expected));
        }

        [Test]
        public void Start_NotConnected_StateChanged()
        {
            _charger.IsConnected = false;
            _charger.Start();

            Assert.That(_receivedArgs, Has.Count.LessThanOrEqualTo(1));
            if (_receivedArgs.Count > 0) Assert.That(_receivedArgs[0].args.After, Is.EqualTo(ChargerState.Idle));
        }

        private void Stop_Setup()
        {
            _charger.IsConnected = true;
            _charger.Start();
            _receivedArgs.Clear();
            _charger.Stop();
        }
        [Test]
        public void Stop_IsConnected()
        {
            Stop_Setup();

            Assert.That(_charger.IsConnected, Is.True);
        }
        [Test]
        public void Stop_State()
        {
            Stop_Setup();

            Assert.That(_charger.State, Is.EqualTo(ChargerState.Idle));
        }
        [Test]
        public void Stop_StateChanged_Count()
        {
            Stop_Setup();

            Assert.That(_receivedArgs, Has.Count.EqualTo(1));
        }
        [Test]
        public void Stop_StateChanged_Sender()
        {
            Stop_Setup();

            Assert.That(_receivedArgs, Has.Count.GreaterThanOrEqualTo(1));
            Assert.That(_receivedArgs[0].sender, Is.EqualTo(_charger));
        }
        [Test]
        public void Stop_StateChanged_After()
        {
            Stop_Setup();

            Assert.That(_receivedArgs, Has.Count.GreaterThanOrEqualTo(1));
            Assert.That(_receivedArgs[0].args.After, Is.EqualTo(ChargerState.Idle));
        }
    }
}
