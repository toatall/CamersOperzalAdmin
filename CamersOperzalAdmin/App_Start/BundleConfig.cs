using System.Web;
using System.Web.Optimization;

namespace CamersOperzalAdmin
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // SB Admin2 template
            bundles.Add(new StyleBundle("~/Content/SBAdmin2/css").Include(
                "~/Content/SBAdmin2/css/sb-admin-2.min.css"));
            bundles.Add(new ScriptBundle("~/Content/SBAdmin2/js").Include(
                "~/Content/SBAdmin2/js/sb-admin-2.min.js"));

            // metis menu
            bundles.Add(new StyleBundle("~/Content/metisMenu/css").Include(
                "~/Content/metisMenu/metisMenu.min.css"));
            bundles.Add(new ScriptBundle("~/Content/metisMenu/js").Include(
                "~/Content/metisMenu/metisMenu.min.js"));

            // font-awesome
            bundles.Add(new StyleBundle("~/Content/font-awesome/css").Include(
                "~/Content/font-awesome/css/font-awesome.min.css"));
        }
    }
}
