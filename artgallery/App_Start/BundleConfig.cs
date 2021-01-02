using System.Web;
using System.Web.Optimization;

namespace artgallery
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Content/js/jquery-1.11.2.min.js",
                        "~/Content/js/jquery.inview.js",
                        "~/Content/js/jquery.viewport.js",
                        "~/Content/js/jquery.isotope.min.js",
                        "~/Content/js/jsplugins.js",
                        "~/Content/js/jquery.prettyPhoto.js",
                        "~/Content/js/jquery.tipTip.minified.js",
                        "~/Content/js/jquery.bxslider.min.js",
                        "~/Content/js/controlpanel.js",
                        "~/Content/js/custom.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Content/js/jquery.validate.min.js",
                        "~/Content/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/style.css",
                      "~/Content/css/animations.css",
                      "~/Content/css/shortcodes.css",
                      "~/Content/css/isotope.css",
                      "~/Content/css/prettyPhoto.css",
                      "~/Content/css/pace.css",
                      "~/Content/css/responsive.css",
                      "~/Content/dark/dark.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/skins/red/style.css"));
        }
    }
}
