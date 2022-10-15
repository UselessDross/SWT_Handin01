using ChargingBox.Application;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using NSubstitute.Callbacks;
using System;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ChargingBox.UnitTests
{
    /*
     * To test Console.Writeline, Use Console.SetOut  (Use StringWriter as the TextWriter)
     */
    public class Tests
    {
        public string path_ = "C:\\semesterFolders\\SWT\\SWTLabEx\\Lektion6\\ChargingBox\\LogTest.txt";
        FileLogger uut;
        [SetUp]
        public void Setup()
        {
            

            uut = new FileLogger(path_);
            

            // what is presummed to be a virtual/mock dicreatory for the unit tests.
            
        }

        [TestCase("C:\\semesterFolders\\SWT\\SWTLabEx\\Lektion6\\ChargingBox\\LogTest.txt")]
        public void TestIs_FilePath_Correct(string result)
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


            //ASSERT

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
            
            
                Assert.That(data_, Is.EqualTo(result+$" {DateTime.Now:u}"));


        }



    }
}