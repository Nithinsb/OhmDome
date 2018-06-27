using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity;

namespace OhmDome
{
    /// <summary>
    /// Type which implements MVC fw's IDependencyResolver interface
    /// </summary>
    public class UnityDependencyResolver:IDependencyResolver
    {

        readonly IUnityContainer _container;

        /// <summary>
        /// .cstor
        /// </summary>
        /// <param name="container"></param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// IDependencyResolver methods
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

    }
}