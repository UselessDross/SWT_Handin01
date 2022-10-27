using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox
{
     class MockKeyReader : IKeyReader
    {
        public event EventHandler<KeyReaderKeyReadEventArgs> KeyRead;
        public KeyReaderKeyReadEventArgs eventArg = new KeyReaderKeyReadEventArgs();
        
        public void changeStateEvent()
        {
            
           // KeyReaderKeyReadEventArgs eventArg = new KeyReaderKeyReadEventArgs();
            
            KeyRead.Invoke(this, eventArg);
        }

        public void change_Key(object key_)
        {

            //KeyReaderKeyReadEventArgs eventArg = new KeyReaderKeyReadEventArgs();
            eventArg.Key = key_;

            //KeyRead.Invoke(this, eventArg);
        }

    }

}
