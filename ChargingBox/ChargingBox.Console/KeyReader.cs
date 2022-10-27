using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.ConsoleImp
{
    public class KeyReader : IKeyReader
    {
        public event EventHandler<KeyReaderKeyReadEventArgs>? KeyRead;

        public void ReadKey(object? key)
        {
            KeyRead?.Invoke(this, new()
            {
                Key = key
            });
        }

    }

}


