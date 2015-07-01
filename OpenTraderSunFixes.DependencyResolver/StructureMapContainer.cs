using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DependencyResolver
{
    public class StructureMapContainer
    {
        private static Lazy<Container> _containerBuilder =
            new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        private static Container defaultContainer()
        {
            return new Container(x =>
            {
                x.AddRegistry(new DefaultRegistry());
            });
        }

        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if (_container == null)
                    _container = defaultContainer();

                return _container;
            }
        }

        public static IContainer GetContainer()
        {
            if (!_containerBuilder.IsValueCreated)
                _containerBuilder = new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

            return defaultContainer();// _containerBuilder.Value;
        }
    }
}
