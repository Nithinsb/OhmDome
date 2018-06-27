using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmDome.Services.Interfaces
{
    /// <summary>
    /// Type which represents the ResistorService. Has capabilities to get valid colors and calculate ohm value
    /// </summary>
    public interface IResistorService
    {
        /// <summary>
        /// Calculates Ohm value of a resistor based on the band colors and returns formatted ohm value
        /// </summary>
        /// <param name="bandAColor"></param>
        /// <param name="bandBColor"></param>
        /// <param name="bandCColor"></param>
        /// <param name="bandDColor"></param>
        /// <returns></returns>
        string CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
        Dictionary<string, int> GetAllowedBandAColors();
        Dictionary<string, int> GetAllowedBandBColors();
        Dictionary<string, double> GetAllowedMultiplierBandColors();
        Dictionary<string, double> GetAllowedToleranceBandColors();
    }
}
