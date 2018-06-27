using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OhmDome.ViewModels;
using OhmDome.Services;
using OhmDome.Services.Interfaces;



namespace OhmDome.Controllers
{
    public class HomeController : Controller
    {
        IResistorService resistorService;

        //Constructor Dependency injection
        public HomeController(IResistorService resistorService)
        {
            this.resistorService = resistorService;
        }
        /// <summary>
        /// Home controller Index method
        /// Loads the home page with list of Band colors
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Get all valid colors for the bands
            ValidColorCodes validColorCodes = new ValidColorCodes();            
            validColorCodes.ValidBandAColors = resistorService.GetAllowedBandAColors().Keys.ToList();
            validColorCodes.ValidBandBColors = resistorService.GetAllowedBandBColors().Keys.ToList();
            validColorCodes.ValidBandCColors = resistorService.GetAllowedMultiplierBandColors().Keys.ToList();
            validColorCodes.ValidBandDColors = resistorService.GetAllowedToleranceBandColors().Keys.ToList();

            return View(validColorCodes);
        }
    }
}
