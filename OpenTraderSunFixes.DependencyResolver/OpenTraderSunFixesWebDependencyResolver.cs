using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenTraderSunFixes.DependencyResolver
{
    public class OpenTraderSunFixesWebDependencyResolver : IDependencyResolver
    {
        private IContainer _container;

        public OpenTraderSunFixesWebDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.GetInstance(serviceType);
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
                return _container.GetAllInstances(serviceType).Cast<object>();
            }
            catch
            {
                return null;
            }
        }
    }
}
