using ChargingBox.Application;

namespace ChargingBox.UnitTests
{
    /*
     * To test Console.Writeline, Use Console.SetOut  (Use StringWriter as the TextWriter)
     */



    public class ExceptionTests
    {
        IDoor uut;
        [SetUp]
        public void Setup()
        {
            uut = new ConsoleDoor(false, false);
        }

        [Test]
        public void CreateDoorOpenANDLocked_ThrowException()
        {
            //Arrange
            //act
            //assert
            Assert.Throws<ArgumentException>(() => uut = new ConsoleDoor(true, true));
        }

        [Test]
        public void Open_openDoor_ThrowException()
        {
            //Arrange
            //act
            uut.Open();
            //assert
            Assert.Throws<InvalidOperationException>(() => uut.Open());
        }


        [Test]
        public void Open_LockedDoor_ThrowException()
        {
            //Arrange
            //act
            uut.Lock();
            //assert
            Assert.Throws<InvalidOperationException>(() => uut.Open());
        }

        [Test]
        public void Close_ThrowException()
        {
            //Arrange
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => uut.Close());
        }

        [Test]
        public void Unlock_unlockedDoor_ThrowException()
        {
            //Arrange
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => uut.Unlock());
        }

        [Test]
        public void lock_lockedDoor_ThrowException()
        {
            //Arrange
            //act
            uut.Lock();
            //assert
            Assert.Throws<InvalidOperationException>(() => uut.Lock());
        }

        [Test]
        public void lock_OpenDoor_ThrowException()
        {
            //Arrange
            //act
            uut.Open();
            //assert
            Assert.Throws<InvalidOperationException>(() => uut.Lock());
        }
    }
}