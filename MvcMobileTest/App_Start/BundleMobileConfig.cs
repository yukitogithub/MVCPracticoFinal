using System.Web;
using System.Web.Optimization;

namespace Practico.MvcMobile {
    public class BundleMobileConfig {
        public static void RegisterBundles(BundleCollection bundles) {

            bundles.Add(new ScriptBundle("~/bundles/jquerymobile")
                .Include("~/Scripts/jquery.mobile-1.4.0.min.js"));

            bundles.Add(new StyleBundle("~/Content/Mobile/css")
                .Include("~/Content/Site.Mobile.css"));
            
            bundles.Add(new StyleBundle("~/Content/jquerymobile/css")
                .Include("~/Content/jquery.mobile-1.4.0.min.css"));
        }
    }
}