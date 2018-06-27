using OhmDome.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OhmDome.Services.Interfaces;

namespace OhmDome.Controllers
{
    /// <summary>
    /// Web API to get the Ohm value based on the colors sent
    /// </summary>
    public class OhmValueController : ApiController
    {
        IResistorService resistorService;
        //Ctor Dependency injection
        public OhmValueController(IResistorService resistorService )
        {
            this.resistorService = resistorService;
        }
        /// <summary>
        /// Passes the ohm value by calling the resistor service
        /// </summary>
        /// <param name="bandAColor"></param>
        /// <param name="bandBColor"></param>
        /// <param name="bandCColor"></param>
        /// <param name="bandDColor"></param>
        /// <returns></returns>
        public string Get(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
             return resistorService.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
        }      



    }
}
