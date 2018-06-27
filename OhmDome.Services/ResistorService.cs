using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhmDome.Domain.Entities;
using OhmDome.Services.Interfaces;
using OhmDome.Domain.Interfaces;
using OhmDome.Domain;
namespace OhmDome.Services
{
    /// <summary>
    /// Service layer for Domain access and any transactions
    /// Provides public methods to get Ohm value and valid color codes
    /// </summary>
    public class ResistorService:IResistorService
    {
        private IResistor resistor;

        /// <summary>
        /// Constructor injection
        /// </summary>
        public ResistorService(IResistor resistor)
        {
            this.resistor = resistor;
        }

        
        public string CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var ohmvalue = resistor.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
            return Utility.FormatNumber(ohmvalue);
        }

        //Get method to get possible Band A Colors
        public Dictionary<string, int> GetAllowedBandAColors()
        {
            return resistor.GetAllowedBandAColors();
        }

        //Get method to get possible Band B Colors
        public Dictionary<string, int> GetAllowedBandBColors()
        {
            return resistor.GetAllowedBandBColors();
        }

        //Get method to get possible Multiplier Colors
        public Dictionary<string, double> GetAllowedMultiplierBandColors()
        {
            return resistor.GetAllowedMultiplierBandColors();
        }

        //Get method to get possible Multiplier Colors
        public Dictionary<string, double> GetAllowedToleranceBandColors()
        {
            return resistor.GetAllowedToleranceBandColors();
        }
    }
}
