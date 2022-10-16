using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox
{
    internal class MockKeyReader : IKeyReader
    {
        public event EventHandler<KeyReaderKeyReadEventArgs> KeyRead;
    }
}
