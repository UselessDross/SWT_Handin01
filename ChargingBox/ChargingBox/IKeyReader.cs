using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingBox
{
    public interface IKeyReader
    {
        event System.EventHandler KeyRead;
    }
}