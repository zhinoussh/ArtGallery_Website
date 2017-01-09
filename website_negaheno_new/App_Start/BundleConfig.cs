using System.Web;
using System.Web.Optimization;

namespace website_negaheno
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                        ,"~/Scripts/jquery.unobtrusive-ajax.min.js"
                         ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                         ,"~/Scripts/respond.min.js"));

       
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/animate.min.css",
                      "~/Content/prettyPhoto.css",
                      "~/Content/site.css",
                       "~/Content/main.css",
                      "~/Content/responsive.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/Dashboardcss").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Dashboard.css",
                      "~/Content/waves.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/WebsiteJS").Include(
                      "~/js/jquery.js",
                      "~/Scripts/bootstrap.min.js",
                        "~/js/jquery.prettyPhoto.js",
                        "~/Areas/Website/Scripts/main.js",
                        "~/Areas/Account/Scripts/login.js",
                        "~/js/wow.min.js",
                        "~/js/waves.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboardJS").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.slimscroll.js",
                     "~/Areas/Admin/Scripts/dashboard.js"                      
                     ));
       
    
        }
    }
}
