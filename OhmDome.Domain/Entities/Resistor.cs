using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhmDome.Domain.Interfaces;
using OhmDome.Domain.Entities;

namespace OhmDome.Domain.Entities
{
    /// <summary>
    /// Type representing a 4 band resistor
    /// Implements IResistor
    /// </summary>
    public class Resistor : IResistor
    {
        private IColorCode colorCode;
        //ctor
        public Resistor(IColorCode colorCode)
        {
            this.colorCode = colorCode;
        }
        //IohmValueCalculator implementation
        public Int64 CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            
            var bandAValue = colorCode.AllBandAColorCodes[bandAColor];
            var bandBValue = colorCode.AllBandBColorCodes[bandBColor];
            var bandCValue = colorCode.AllMultiplierColorCodes[bandCColor];
            var frstTwobands = (bandAValue * 10) + bandBValue;
            Int64 ohmValue =Convert.ToInt64(frstTwobands * bandCValue);

            return ohmValue;
        }

        //Get method to get possible Band A Colors
        public Dictionary<string, int> GetAllowedBandAColors()
        {
            
            return colorCode.AllBandAColorCodes;
        }

        //Get method to get possible  Band B Colors
        public Dictionary<string, int> GetAllowedBandBColors()
        {
            return colorCode.AllBandBColorCodes;
        }


        //Get method to get possible Multiplier Colors
        public Dictionary<string, double> GetAllowedMultiplierBandColors()
        {
            return colorCode.AllMultiplierColorCodes;
        }

        //Get method to get possible Multiplier Colors
        public Dictionary<string, double> GetAllowedToleranceBandColors()
        {

            return colorCode.AllToleranceColorCodes;
        }

    }
}
