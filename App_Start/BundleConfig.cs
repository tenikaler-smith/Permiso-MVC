using System.Web;
using System.Web.Optimization;

namespace PersimosMVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/funciones").Include(
                      "~/Scripts/funciones.js"));

            bundles.Add(new StyleBundle("~/bundles/js").Include(
                     "~/admin-lte/js/adminlte.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/pnotify.custom.min.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/animate.css",

                      "~/Content/animate.css",

                      "~/Content/site.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/skins/skin-blue.min.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/pnotify.custom.min.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/adminLTE").Include(
                     "~/admin-lte/css/AdminLTE.css"));
        }
    }
    
}
