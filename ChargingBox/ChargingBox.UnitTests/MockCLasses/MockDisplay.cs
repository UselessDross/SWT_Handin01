using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox
{
    internal class MockDisplay : IDisplay
    {
        public void Display(string text)
        {
            throw new NotImplementedException();
        }
    }
}
