using System.Web;
using System.Web.Optimization;

namespace SunRise
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js", "~/Scripts/image_slide.js", "~/Scripts/jquery.easing-sooper.js", "~/Scripts/jquery.min.js", "~/Scripts/jquery.sooperfish.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/style.css", "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                   
                      "~/Content/bootstrap-responsive.css"
                      ));
        }
    }
}
