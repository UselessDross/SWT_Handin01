using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.ConsoleImp
{
    public class DIsplay : IDisplay
    {
        // vise "tilsult telefon"
        // vise "indlæs RFID"
        // vise "tilsultinsgfejl"
        // vise "Ladeskabe Optaget"
        // vise "RFID fejl"
        // vise "fjern telefon"
        public void Display(string text)
        {
            Console.WriteLine(text);
        }
    }
}
