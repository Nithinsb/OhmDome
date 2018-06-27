using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Resources;
using OhmDome.Domain.Interfaces;
namespace OhmDome.Domain.Entities
{
    /// <summary>
    /// Type represtning valid color codes. (This along with the color code XML acts as DB Context) 
    /// It has private method to read from Colorcode XML
    /// Implements IColorCode
    /// </summary>
    public class ColorCode:IColorCode
    {
        private XDocument ohmDomeXML;

        /// <summary>
        /// IColorCode properties
        /// </summary>
        public Dictionary<string, int> AllBandAColorCodes { get; set; }
        public Dictionary<string, int> AllBandBColorCodes { get; set; }

        public Dictionary<string, double> AllMultiplierColorCodes { get; set; }
        public Dictionary<string, double> AllToleranceColorCodes { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ColorCode()
        {
            
            AllBandAColorCodes = new Dictionary<string, int>();
            AllBandBColorCodes = new Dictionary<string, int>();
            AllMultiplierColorCodes = new Dictionary<string, double>();
            AllToleranceColorCodes = new Dictionary<string, double>();
            loadColorCodes();
        }

        /// <summary>
        /// Private method to load the color codes
        /// </summary>
        private void loadColorCodes()
        {
                       
            //Load AllBandColorCodes
            ohmDomeXML = XDocument.Parse(Resources.OhmDomeDB);

            //Load possible colors for Bands 1 
            foreach (XElement element in ohmDomeXML.Descendants("BandA").Descendants())
            {
                AllBandAColorCodes.Add(element.FirstAttribute.Value.ToString(), Convert.ToInt32(element.Value));
            }

            //Load possible colors for Bands 2 
            foreach (XElement element in ohmDomeXML.Descendants("BandB").Descendants())
            {
                AllBandBColorCodes.Add(element.FirstAttribute.Value.ToString(), Convert.ToInt32(element.Value));
            }
            //Load possible colors for Multiplier
            foreach (XElement element in ohmDomeXML.Descendants("Multiplier").Descendants())
            {
                AllMultiplierColorCodes.Add(element.FirstAttribute.Value.ToString(), Convert.ToDouble(element.Value));
            }
            //Load possible colors for Tolerance
            foreach (XElement element in ohmDomeXML.Descendants("Tolerance").Descendants())
            {
                AllToleranceColorCodes.Add(element.FirstAttribute.Value.ToString(), Convert.ToDouble(element.Value));
            }
        }



    }
}
