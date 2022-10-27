using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.UnitTests
{
    public class KeyReaderUnitTests
    {
        private KeyReader _keyReader;
        private List<(object? sender, KeyReaderKeyReadEventArgs args)> _receivedArgs;

        [SetUp]
        public void Setup()
        {
            _keyReader = new();

            _receivedArgs = new();
            _keyReader.KeyRead += (object? sender, KeyReaderKeyReadEventArgs args) =>
            {
                _receivedArgs.Add(new(sender, args));
            };
        }

        [Test]
        public void OnKeyRead_Count()
        {
            _keyReader.ReadKey(1);

            Assert.That(_receivedArgs, Has.Count.EqualTo(1));
        }
        [Test]
        public void OnKeyRead_Sender()
        {
            _keyReader.ReadKey(1);

            Assert.That(_receivedArgs, Has.Count.GreaterThanOrEqualTo(1));
            Assert.That(_receivedArgs[0].sender, Is.EqualTo(_keyReader));
        }
        [TestCase("Abcda")]
        [TestCase(124)]
        [TestCase(null)]
        public void OnKeyRead_Key(object? key)
        {
            _keyReader.ReadKey(key);

            Assert.That(_receivedArgs, Has.Count.GreaterThanOrEqualTo(1));
            Assert.That(_receivedArgs[0].args.Key, Is.EqualTo(key));
        }
    }
}
