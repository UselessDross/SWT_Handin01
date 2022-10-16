using ChargingBox.UnitTests.MockCLasses;

namespace ChargingBox.UnitTests
{
    /*
     * To test Console.Writeline, Use Console.SetOut  (Use StringWriter as the TextWriter)
     */



    public class Tests
    {
        ChargingBox uut;
        [SetUp]
        public void Setup()
        {
            uut = new ChargingBox(new MockDoor(),new MockCharger(), new MockKeyReader(), new MockDisplay(),new MockLogger());
        }

        [Test]
        public void Trylock_returnsTrue_isCorrect()
        {
        //ARRANGE
            /*chargingBoxState is 'Available'*/
            uut.State = ChargingBoxState.Available;
            /*Door is closed, door.IsOpen is false*/
            uut.Door.Close();
            /*Charger IsConnected is True*/
            uut.Charger.IsConnected = true;

            //act
            

            //assert
            
        }
    }
}