using OhmDome.Domain.Entities;
using OhmDome.Domain.Interfaces;
using OhmDome.Services;
using OhmDome.Services.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace OhmDome
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IResistorService, ResistorService>();
            container.RegisterType<IResistor, Resistor>();
            container.RegisterType<IColorCode, ColorCode>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}