using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingBox
{
    public interface ILogger
    {
        void LogLock(bool lockState, object key);
    }
}