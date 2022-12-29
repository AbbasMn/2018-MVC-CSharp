using System.Web;
using System.Web.Optimization;

namespace MVC
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



            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/bootbox.js", // Add Bootbox Plug-in
            //          "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/lib").Include(    // MVC: define a library for scripts to use in View/Shared/_Layout.cshtml
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js", // MVC: Add Bootbox Plug-in

                      "~/Scripts/respond.js",

                      "~/Scripts/DataTables/jquery.dataTables.js",       // MVC: used for Data Tables Plug-in (Add pagination, sorting and filtering)   
                      "~/Scripts/DataTables/dataTables.bootstrap.js"));  // MVC: used for Data Tables Plug-in (Add pagination, sorting and filtering)


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css"));  // MVC: datatables.bbotstrap.css make data table like bootstarp table
        }
    }
}
