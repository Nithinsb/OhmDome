using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmDome.Domain.Interfaces
{
    /// <summary>
    /// All the valid color codes for a 4 band resistor
    /// </summary>
    public interface IColorCode
    {
        Dictionary<string, int> AllBandAColorCodes { get; set; }
        Dictionary<string, int> AllBandBColorCodes { get; set; }

        Dictionary<string, double> AllMultiplierColorCodes { get; set; }
        Dictionary<string, double> AllToleranceColorCodes { get; set; }
    }
}
