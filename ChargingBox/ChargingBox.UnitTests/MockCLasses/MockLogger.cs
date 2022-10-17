using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.UnitTests.MockCLasses
{
    internal class MockLogger : ILogger
    {
        public void LogLock(bool lockState, object key, string filepath)
        {
            
        }
    }
}
