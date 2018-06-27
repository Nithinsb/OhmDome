using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmDome.Domain.Interfaces
{
    /// <summary>
    /// Type representing Ohm Value calculator capability
    /// </summary>
    public interface IOhmValueCalculator
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        Int64 CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);

        //SHOULD HAVE METHOD DEFINITIONS RETURNING STRING IN THE FUTURE. THIS IS TO RETURN TOLERANCE VALUE
        
    }
}
