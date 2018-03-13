using System;
using System.Collections.Generic;
using StudyGroup.DAL;
using System.Data.Entity.Infrastructure.Interception;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudyGroup
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbInterception.Add(new GroupStudyInterceptorTransientErrors());
            DbInterception.Add(new GroupStudyInterceptorLogging());
        }
    }
}
