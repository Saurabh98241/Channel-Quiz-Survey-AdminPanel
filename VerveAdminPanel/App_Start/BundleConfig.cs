using System.Web;
using System.Web.Optimization;

namespace VerveAdminPanel
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/bootstrap.min.css",
                       "~/Content/css/font-awesome.min.css",
                       "~/Content/css/ionicons.min.css",
                        "~/Content/css/morris/morris.css",
                        "~/Content/css/jvectormap/jquery-jvectormap-1.2.2.css",
                        "~/Content/css/fullcalendar/fullcalendar.css",
                        "~/Content/css/daterangepicker/daterangepicker-bs3.css",
                        "~/Content/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                        "~/Content/css/AdminLTE.css",
                        "~/Content/css/Custom.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/ThemeJs").Include(
                     //"http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js",
                     "~/Content/js/jquery-ui-1.10.3.min.js",
                     "~/Content/js/bootstrap.min.js",
                     
                     "~/Content/js/plugins/morris/morris.min.js",
                     "~/Content/js/plugins/sparkline/jquery.sparkline.min.js",
                     "~/Content/js/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                     "~/Content/js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                     "~/Content/js/plugins/fullcalendar/fullcalendar.min.js",
                     "~/Content/js/plugins/jqueryKnob/jquery.knob.js",
                     "~/Content/js/plugins/daterangepicker/daterangepicker.js",
                     "~/Content/js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                     "~/Content/js/plugins/iCheck/icheck.min.js",
                     "~/Content/js/AdminLTE/app.js"

                     ));
            bundles.Add(new ScriptBundle("~/bundles/DataTable").Include(
                      "~/Content/js/plugins/datatables/jquery.dataTables.js",
                      "~/Content/js/plugins/datatables/dataTables.bootstrap.js"
                   ));
        }
    }
}
