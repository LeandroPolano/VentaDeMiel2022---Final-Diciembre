using System.Web;
using System.Web.Optimization;

namespace VentaDeMiel2022.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/PagedList.css",
                "~/Content/site.css"));

            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/complementos").Include(
                 "~/Scripts/DataTables/jquery.dataTables.js",
                 "~/Scripts/DataTables/dataTables.responsive.js",
                 "~/Scripts/fontawesome/all.min.js",
                 "~/Scripts/scripts.js"
             ));


            //bundles.Add(new Bundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new Bundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
            bundles.Add(new Bundle("~/bundles/modernizr").Include(
                       "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/fontawesome/all.min.js",
                "~/Scripts/loadingoverlay.js",
                "~/Scripts/sweetalert.min.js",
                 "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
               "~/Content/DataTables/css/jquery.dataTables.css",
               "~/Content/DataTables/css/responsive.dataTables.css",
               "~/Content/bootstrap.css",
               "~/Content/sweetalert.css",
               "~/Content/PagedList.css",
               "~/Content/site.css"));
        }
    } 
}
