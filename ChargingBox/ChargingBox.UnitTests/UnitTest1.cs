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
        }

        [Test]
        public void ChargingBoxState_isError_correct()
        {
            //ARRANGE
            ICharger charger_ = new MockCharger();
            charger_.State=ChargerState.Error;

            IDoor door_ = new MockDoor();
            door_.IsLocked = false;
           
           //ACT
            uut = new ChargingBox(door_,
                                  charger_, 
                                  new MockKeyReader(), 
                                  new MockDisplay(),
                                  new MockLogger());

            //ASSERT
            Assert.That(uut.State, Is.EqualTo(ChargingBoxState.Error));
        }





        [TestCase(ChargerState.Idle, 
                  ChargerState.Idle, 
                  ChargerState.Idle, 
                  ChargingBoxState.Available,
                  ChargingBoxState.Available)]
        [TestCase(ChargerState.Idle,
                  ChargerState.Idle,
                  ChargerState.Idle,
                  ChargingBoxState.Locked,
                  ChargingBoxState.Locked)]
        [TestCase(ChargerState.Idle,
                  ChargerState.Idle,
                  ChargerState.Idle,
                  ChargingBoxState.Unlocked,
                  ChargingBoxState.Available)]
        [TestCase(ChargerState.Idle,
                  ChargerState.Error,
                  ChargerState.Idle,
                  ChargingBoxState.Available,
                  ChargingBoxState.Error)]
        [TestCase(ChargerState.Idle,
                  ChargerState.Idle,
                  ChargerState.Idle,
                  ChargingBoxState.Error,
                  ChargingBoxState.Error)]
        public void HandleChargerStateChanged_GivesResultCorrect(ChargerState ChargState_, 
                                                                 ChargerState AfterState_, 
                                                                 ChargerState BeforState_,
                                                                 ChargingBoxState uutBaseState, 
                                                                 ChargingBoxState result_)
        {
            //ARRANGE
            MockCharger charger_ = new MockCharger();
            charger_.State = ChargerState.Idle;

            //ACT
            uut = new ChargingBox(new MockDoor(),
                                 charger_,
                                 new MockKeyReader(),
                                 new MockDisplay(),
                                 new MockLogger());
            uut.State = uutBaseState;
            charger_.changeStateEvent(ChargState_, AfterState_, BeforState_);
            
            //ASSERT
            Assert.That(uut.State, Is.EqualTo(result_));
        }


        [TestCase(true , false, ChargingBoxState.Available, ChargingBoxState.Locked)]
        [TestCase(true , true , ChargingBoxState.Available, ChargingBoxState.Available)]
        [TestCase(false, false, ChargingBoxState.Available, ChargingBoxState.Available)]
        //[TestCase(true, false, ChargingBoxState.Available, ChargingBoxState.Available)] does fail. the tests maches expectations.
        public void Trylock_GivesCorrectResult(bool connection, 
                                               bool Door ,
                                               ChargingBoxState uutBaseState, 
                                               ChargingBoxState result_)
        {
            //ARRANGE
            MockKeyReader keyReader_ = new MockKeyReader();
            
            


            //ACT
            uut = new ChargingBox(new MockDoor(),
                                  new MockCharger(),
                                  keyReader_,
                                  new MockDisplay(),
                                  new MockLogger());
            uut.State = uutBaseState;
            uut.Charger.IsConnected = connection;
            uut.Door.IsOpen = Door;


            keyReader_.changeStateEvent();

            //ASSERT
            Assert.That(uut.State, Is.EqualTo(result_));

        }

      
        [TestCase("Base_key", ChargingBoxState.Available, "Base_key", ChargingBoxState.Available)]
        [TestCase("Base_key", ChargingBoxState.Available, "notBase_key", ChargingBoxState.Locked)]
        [TestCase("Base_key", ChargingBoxState.Available, null, ChargingBoxState.Locked)]
        public void TryUnlock_GivesCorrectResult(object KeyUsedToLockBox,
                                                 ChargingBoxState uutBaseState,
                                                 object KeyUsedToUnLockBox,
                                                 ChargingBoxState result_)
        {
            //ARRANGE
            MockKeyReader keyReader_ = new MockKeyReader();
            uut = new ChargingBox(new MockDoor(),
                                  new MockCharger(),
                                  keyReader_,
                                  new MockDisplay(),
                                  new MockLogger());
            uut.Charger.IsConnected = true;
            uut.Door.IsOpen = false;
            keyReader_.change_Key(KeyUsedToLockBox);
            uut.State = uutBaseState;
            keyReader_.changeStateEvent();
                 //Assert.That(uut.State, Is.EqualTo(ChargingBoxState.Locked));


            //ACT
            keyReader_.change_Key(KeyUsedToUnLockBox);
            keyReader_.changeStateEvent();
         
            //ASSERT
            Assert.That(uut.State, Is.EqualTo(result_));
        }




        public void UpdateDisplay_DisplaysCorrect()
        {
            //ARRANGE
            MockKeyReader keyReader_ = new MockKeyReader();
            uut = new ChargingBox(new MockDoor(),
                                  new MockCharger(),
                                  keyReader_,
                                  new MockDisplay(),
                                  new MockLogger());
            uut.Charger.IsConnected = true;
            uut.Door.IsOpen = false;
            keyReader_.change_Key(KeyUsedToLockBox);
            uut.State = uutBaseState;
            keyReader_.changeStateEvent();
            //Assert.That(uut.State, Is.EqualTo(ChargingBoxState.Locked));


            //ACT
            keyReader_.change_Key(KeyUsedToUnLockBox);
            keyReader_.changeStateEvent();

            //ASSERT
            Assert.That(uut.State, Is.EqualTo(result_));
        }


    }
}