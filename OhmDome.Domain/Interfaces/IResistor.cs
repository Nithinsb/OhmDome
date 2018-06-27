using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmDome.Domain.Interfaces
{
    /// <summary>
    /// Type representing a 4 band resistor
    /// Implements IOhmValueCalculator
    /// </summary>
    public interface IResistor:IOhmValueCalculator
    {
        //Get method to get possible Band A Colors
        Dictionary<string, int> GetAllowedBandAColors();
        
        //Get method to get possible  Band B Colors
         Dictionary<string, int> GetAllowedBandBColors();
        


        //Get method to get possible Multiplier Colors
         Dictionary<string, double> GetAllowedMultiplierBandColors();
       

        //Get method to get possible Multiplier Colors
         Dictionary<string, double> GetAllowedToleranceBandColors();
        
    }
}
