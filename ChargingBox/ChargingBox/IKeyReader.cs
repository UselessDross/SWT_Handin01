using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingBox
{
    public class KeyReaderKeyReadEventArgs
    {
        public object? Key;
    }

    public interface IKeyReader
    {
        event System.EventHandler<KeyReaderKeyReadEventArgs> KeyRead;
    }
}