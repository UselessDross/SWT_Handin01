using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.Application
{
    public class KeyReader : IKeyReader
    {
        public event EventHandler<KeyReaderKeyReadEventArgs> KeyRead;

        public void OnKeyRead(KeyReaderKeyReadEventArgs e)
        {
            KeyRead?.Invoke(this, e);
        }

    }
    /*
    public class something
    {
        void some(object o, KeyReaderKeyReadEventArgs e) { /*busniss logic }
        public something(IKeyReader reader)
        {
            reader.KeyRead += some;
        } 

    }
*/

}


