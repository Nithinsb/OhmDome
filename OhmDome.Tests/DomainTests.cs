using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmDome.Domain.Entities;
using OhmDome.Domain.Interfaces;
using System.Collections.Generic;
using Moq;


namespace OhmDome.Tests
{
    [TestClass]
    public class DomainTests
    {
        Dictionary<string, int> AllBandAColorCodes;
        Dictionary<string, int> AllBandBColorCodes;
        Dictionary<string, double> AllBandCColorCodes;
        Dictionary<string, double> AllBandDColorCodes;
        Mock<IColorCode> colorCode;
        [TestInitialize]
        public void Initialize()
        {
             AllBandAColorCodes = new Dictionary<string, int>();
             AllBandBColorCodes = new Dictionary<string, int>();
             AllBandCColorCodes = new Dictionary<string, double>();
             AllBandDColorCodes = new Dictionary<string, double>();

             AllBandAColorCodes.Add("Red", 0);
             AllBandAColorCodes.Add("Black", 1);
             AllBandAColorCodes.Add("Orange", 2);

             AllBandBColorCodes.Add("Red", 0);
             AllBandBColorCodes.Add("Black", 1);
             AllBandBColorCodes.Add("Orange", 2);

             AllBandCColorCodes.Add("Red", 10000);
             AllBandCColorCodes.Add("Black", 10000000);
             AllBandCColorCodes.Add("Orange", 1000000000);
             AllBandCColorCodes.Add("Green", 0.1);

             AllBandDColorCodes.Add("Red", 0.1);
             AllBandDColorCodes.Add("Black", 0.25);
             AllBandDColorCodes.Add("Orange", 1);

             colorCode = new Mock<IColorCode>();
             colorCode.Setup(x => x.AllBandAColorCodes).Returns(AllBandAColorCodes);
             colorCode.Setup(x => x.AllBandBColorCodes).Returns(AllBandBColorCodes);
             colorCode.Setup(x => x.AllMultiplierColorCodes).Returns(AllBandCColorCodes);
             colorCode.Setup(x => x.AllToleranceColorCodes).Returns(AllBandDColorCodes);            
        }
        [TestMethod]
        public void CheckCalculateOhmValueForCorrectValue()
        {           
            var resistor = new Resistor(colorCode.Object);
            Assert.AreEqual(120000,resistor.CalculateOhmValue("Black","Orange","Red","Red"));
        }

        [TestMethod]
        public void CheckCalculateOhmValueForIncorrectValue()
        {
            
            var resistor = new Resistor(colorCode.Object);
            Assert.AreNotEqual(130000, resistor.CalculateOhmValue("Black", "Orange", "Red", "Red"));
        }

        [TestMethod]
        public void IsGetAllowedBandAColorsReturningCorrectObject()
        {
            
            var resistor = new Resistor(colorCode.Object);
            Assert.AreSame(AllBandAColorCodes, resistor.GetAllowedBandAColors());
        }

        [TestMethod]
        public void IsGetAllowedBandBColorsReturningCorrectObject()
        {
            
            var resistor = new Resistor(colorCode.Object);
            Assert.AreSame(AllBandBColorCodes, resistor.GetAllowedBandBColors());
        }

        [TestMethod]
        public void IsGetAllowedBandCColorsReturningCorrectObject()
        {
            
            var resistor = new Resistor(colorCode.Object);
            Assert.AreSame(AllBandCColorCodes, resistor.GetAllowedMultiplierBandColors());
        }
        [TestMethod]
        public void IsGetAllowedBandDColorsReturningCorrectObject()
        {            
            var resistor = new Resistor(colorCode.Object);
            Assert.AreSame(AllBandDColorCodes, resistor.GetAllowedToleranceBandColors());
        }


       
    }
}
