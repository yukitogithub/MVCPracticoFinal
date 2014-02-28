using System.Web;
using System.Web.Optimization;

namespace Practico.MvcMobile {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-1.6.4.min.js"));
        }
    }
}