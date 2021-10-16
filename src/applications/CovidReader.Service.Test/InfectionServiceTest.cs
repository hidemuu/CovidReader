using CovidReader.Service;
using CovidReader.Models.Api;
using CovidReader.Repository.Api;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace CovidReader.Test
{
    public class InfectionServiceTest
    {
        private InfectionServiceBuilder _infectionServiceBuilder;
        
        [OneTimeSetUp]
        public void ClassInitialize()
        {
            Trace.WriteLine("UnitTest1 ClassInitialize");
        }

        [SetUp]
        public void Setup()
        {
            _infectionServiceBuilder = new InfectionServiceBuilder();
            
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
        public void CalcDaily()
        {
            //Arrange
            var sut = _infectionServiceBuilder.WithInfectionCalled().Build();
            
            //Act


            //Assert
            Assert.Pass();
            int param = 5;
            int answer = 15;
            Assert.AreEqual(answer, param, $"足し算ロジックNG：param={param}");
        }

        [Test]
        public void CalcTotal()
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
