using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmDome.Services
{
    /// <summary>
    /// Utility class which provides general utility services like number formating
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Method to convert 1000 to K, 1000000 to M, 1000000000 to G
        /// </summary>
        /// <param name="Number"></param>
        /// <returns>formatted string</returns>
        public static string FormatNumber(long Number)
        {
            if (Number >= 1000 && Number <=1000000)
                return string.Concat(Number / 1000, "K");
            else if (Number >= 1000000 && Number <= 1000000000)
                return string.Concat(Number / 1000000, "M");
            else if (Number >= 1000000000)
                return string.Concat(Number / 1000000000, "G");
            else
                return Number.ToString();
        }
    }
}
