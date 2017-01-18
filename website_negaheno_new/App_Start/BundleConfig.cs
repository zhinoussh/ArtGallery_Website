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
                      "~/Content/website.min.css",
                      "~/Content/responsive.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/Dashboardcss").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/fileinput.min.css",
                      "~/Content/Dashboard.css",
                      "~/Content/admin.min.css",
                      "~/Content/waves.css",
                      "~/Content/PagedList.css",
                      "~/Content/bootstrap-datepicker.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/WebsiteJS").Include(
                      "~/Scripts/bootstrap.min.js",
                        "~/Areas/Website/Scripts/main.js",
                        "~/Scripts/wow.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboardJS").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.slimscroll.js",
                      "~/Scripts/fileinput.min.js",
                     "~/Areas/Admin/Scripts/dashboard.js",
                     "~/Areas/Admin/Scripts/admin.js",
                        "~/Scripts/waves.js",
                        "~/Scripts/bootstrap-datepicker.fa.min.js",
                        "~/Scripts/bootstrap-datepicker.min.js",
                         "~/Scripts/bootstrap-timepicker.min.js"
                     ));
       
    
        }
    }
}
