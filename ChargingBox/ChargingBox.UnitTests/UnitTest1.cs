namespace ChargingBox.UnitTests
{
    /*
     * To test Console.Writeline, Use Console.SetOut  (Use StringWriter as the TextWriter)
     */



    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.That(uut.Filepath, Is.EqualTo(result));
        }

        

        [TestCase("ALPHA", "Locked with key ALPHA at")]
        [TestCase("BRAVO", "Locked with key BRAVO at")]
        [TestCase("CHARLI", "Locked with key CHARLI at")]
        public void TestIs_LogLock_Correct(string a, string result)
        {
            // Arrange
            string data_;
            StreamReader reader = null;
            
            
            //ACT
            System.IO.File.WriteAllText(path_, string.Empty);
            uut.LogLock(true,a,path_);
            try
            {
                reader = new StreamReader(uut.Filepath);
                data_ = reader.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
            }
            
            
            //ASSERT
            Assert.That(data_, Is.EqualTo(result+$" {DateTime.Now:u}"));
        }

        [TestCase("ALPHA", "Unlocked with key ALPHA at")]
        [TestCase("BRAVO", "Unlocked with key BRAVO at")]
        [TestCase("CHARLI", "Unlocked with key CHARLI at")]
        public void TestIs_UnLogLock_Correct(string a, string result)
        {
            // Arrange
            string data_;
            StreamReader reader = null;


            //ACT
            System.IO.File.WriteAllText(path_, string.Empty);
            uut.LogLock(false, a, path_);
            try
            {
                reader = new StreamReader(uut.Filepath);
                data_ = reader.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
            }


            //ASSERT
            Assert.That(data_, Is.EqualTo(result + $" {DateTime.Now:u}"));
        }

        [TestCase(1900, 10, 01, "1900-10-01 00:00:00Z")]
        [TestCase(2008, 11, 01, "2008-11-01 00:00:00Z")]
        [TestCase(1927, 02, 01, "1927-02-01 00:00:00Z")]
        public void TestIs_LogLock_withTimespecification_Correct(int YYYY,int mm,int dd, string result)
        {
            // Arrange
            string data_;
            StreamReader reader = null;
            DateTime testTime = new DateTime(YYYY, mm, dd);


            //ACT
            System.IO.File.WriteAllText(path_, string.Empty);
            uut.LogLock(false, "ALPHA",testTime);
            try
            {
                reader = new StreamReader(uut.Filepath);
                data_ = reader.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
            }

            data_ = data_.Replace("Unlocked with key ALPHA at ", "");

            //ASSERT
            Assert.That(data_, Is.EqualTo(result));
        }
        

    }
}