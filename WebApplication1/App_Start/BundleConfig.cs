using System.Web;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/owlcarousel/css").Include(
                "~/Content/lib/owlcarousel/assets/owl.carousel.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                "~/Content/lib/animate/animate.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/tempusdominus/css").Include(
                "~/Content/lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/twentytwenty/css").Include(
                "~/Content/lib/twentytwenty/twentytwenty.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                "~/css/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/wow/js").Include(
                "~/Content/lib/wow/wow.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/easing/js").Include(
                "~/Content/lib/easing/easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/waypoints/js").Include(
                "~/Content/lib/waypoints/waypoints.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlcarousel/js").Include(
                "~/Content/lib/owlcarousel/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment/js").Include(
                "~/Content/lib/tempusdominus/js/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/timezone/js").Include(
                "~/Content/lib/tempusdominus/js/moment-timezone.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tempusdominus/js").Include(
                "~/Content/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryevent/js").Include(
                "~/Content/lib/twentytwenty/jquery.event.move.js"));

            bundles.Add(new ScriptBundle("~/bundles/twentytwenty/js").Include(
                "~/Content/lib/twentytwenty/jquery.twentytwenty.js"));

            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                "~/js/main.js"));
        }
    }
}
