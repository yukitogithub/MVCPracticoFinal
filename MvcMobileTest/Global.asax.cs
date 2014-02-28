using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Web.WebPages;

namespace Practico.MvcMobile
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Android")
            {
                ContextCondition = (context => context.Request.UserAgent.IndexOf
                    ("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("WindowsPhone")
            {
                ContextCondition = (context => context.Request.UserAgent.IndexOf
                    ("Windows Phone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context => context.Request.UserAgent.IndexOf
                    ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["Answers"] = null;
            Session["Test"] = null;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //Session["User"] = null;
            //Session["Answers"] = null;
            //Session["Test"] = null;
        }
    }
}