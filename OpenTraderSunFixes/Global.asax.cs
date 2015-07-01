using OpenTraderSunFixes.DependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OpenTraderSunFixes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = StructureMapContainer.Container;
            System.Web.Mvc.DependencyResolver.SetResolver(new OpenTraderSunFixesWebDependencyResolver(container));
            //ModelBinders.Binders.Add(typeof(OpenTraderSunFixes.Model.SunFixAttributes), new OpenTraderSunFixes.Infrastructure.ModelBinders.SunFixAttributesModelBinder());

        }
    }
}
