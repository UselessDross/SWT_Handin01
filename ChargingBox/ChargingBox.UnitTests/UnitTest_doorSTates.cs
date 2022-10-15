using ChargingBox.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargingBox.UnitTests
{
    internal class UnitTest_doorSTates
    {
        ConsoleDoor uut;
        [SetUp]
        public void Setup()
        {
            uut = new ConsoleDoor(false, false);
        }

        [Test]
        public void Open_change_IsOpenState_to_true()
        {
            //arrange
            //act
            uut.Open();
            //assert
            Assert.That(uut.IsOpen, Is.True);
        }

        [Test]
        public void Close_change_IsOpenState_to_false()
        {
            //arrange
            uut.Open();
            //act
            uut.Close();
            //assert
            Assert.That(uut.IsOpen, Is.False);
        }
        [Test]
        public void Lock_change_IsLockedState_to_true()
        {
            //arrange
            //act
            uut.Lock();
            //assert
            Assert.That(uut.IsLocked, Is.True);
        }
        [Test]
        public void UnLock_change_IsLockedState_to_false()
        {
            //arrange
            uut.Lock();
            //act
            uut.Unlock();
            //assert
            Assert.That(uut.IsLocked, Is.False);
        }

        [TestCase(false,false, "unlocked", "closed")]
        [TestCase(false,true, "locked", "closed")]
        [TestCase(true,false, "unlocked", "open")]
        public void GetString_IsCOrrect(bool a, bool b, string result1, string reslut2)
        {
            //arrange


            //act

            if (a) { uut.Open();   }
            

            if (b) { uut.Lock();   }
            


            //assert
            if (uut.IsLocked==false)
            {
                if (uut.IsOpen)
                {
                    Assert.That(uut.GetState(), Is.EqualTo("Door is " + result1 + " and " + reslut2));
                }
                else 
                { 
                    Assert.That(uut.GetState(), Is.EqualTo("Door is " + result1 + " and " + reslut2));
                }
            }
            else if (uut.IsLocked && uut.IsOpen==false)
            {
                Assert.That(uut.GetState(), Is.EqualTo("Door is " + result1 + " and " + reslut2));
            }


        }
    }
}
