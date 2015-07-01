using OpenTraderSunFixes.DomainService;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTraderSunFixes.Repository;
using System.Data.Entity;
using OpenTraderSunFixes.Repository.EF;
using OpenTraderSunFixes.Model;

namespace OpenTraderSunFixes.DependencyResolver
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.Assembly(typeof(ISunService).Assembly);
                scan.WithDefaultConventions();
                //scan.SingleImplementationsOfInterface();
                For<DbContext>().Use(() => new SunDBContext());
                For(typeof(IRepository<>)).Use(typeof(EFRepository<>)).Ctor<DbContext>();
                For<ICCTransactionRepository>().Use<CCTransactionRepository>().Ctor<DbContext>();
                //For<ISunService>().Use<SunService>();
                For<SunFixStrategy>().Add<SunXMLFixStrategy>().Named(SunFixType.Sun.ToString());
                For<SunFixStrategy>().Add<SunTraderFixStrategy>().Named(SunFixType.Trader.ToString());

            });
        }
    }
}
