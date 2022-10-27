using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.UnitTests
{
    public class DIsplayUnitTest
    {
        StringWriter _consoleOutput;
        IDisplay _display;

        [SetUp]
        public void Setup()
        {
            _consoleOutput = new();
            Console.SetOut(_consoleOutput);
            _display = new DIsplay();
        }

        [TestCase("Test ABC", "Test ABC\r\n")]
        [TestCase("123 #^$#", "123 #^$#\r\n")]
        [TestCase("\n test abb \\n", "\n test abb \\n\r\n")]
        public void Display(string input, string expected)
        {
            _display.Display(input);
            _consoleOutput.Close();

            string actual = _consoleOutput.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
