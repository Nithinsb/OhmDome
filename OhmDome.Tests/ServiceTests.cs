using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OhmDome.Domain.Entities;
using OhmDome.Domain.Interfaces;
using OhmDome.Services.Interfaces;
using OhmDome.Services;

namespace OhmDome.Tests
{
    [TestClass]
    public class ServiceTests
    {
        Mock<IResistorService> resistorService;
        Mock<IResistor> resistor;
        Mock<IColorCode> colorCode;
        [TestInitialize]
        public void Initialize()
        {
            colorCode = new Mock<IColorCode>();
            resistor = new Mock<IResistor>();
            
        }
        [TestMethod]
        public void IsCalculateOhmValueReturningCorrectFormattedValue()
        {
            resistor.Setup(x=>x.CalculateOhmValue("","","","")).Returns(120000);
            var resistorService = new ResistorService(resistor.Object);
            Assert.AreEqual("120K", resistorService.CalculateOhmValue("", "", "", ""));
        }
    }
}
