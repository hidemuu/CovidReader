using NUnit.Framework;
using System.Diagnostics;

namespace CovidReader.Test
{
    public class InspectionServiceTest
    {
        [OneTimeSetUp]
        public void ClassInitialize()
        {
            Trace.WriteLine("UnitTest1 ClassInitialize");
        }

        [SetUp]
        public void Setup()
        {
            Trace.WriteLine("UnitTest1 TestInitialize");
        }

        [TearDown]
        public void TestCleanup()
        {
            Trace.WriteLine("UnitTest1 TestCleanup");
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            Trace.WriteLine("UnitTest1 ClassCleanup");
        }


        [Test]
        public void Test1()
        {
            //Arrange

            //Act

            //Assert
            Assert.Pass();
            int param = 5;
            int answer = 15;
            Assert.AreEqual(answer, param, $"足し算ロジックNG：param={param}");
        }
    }
}
