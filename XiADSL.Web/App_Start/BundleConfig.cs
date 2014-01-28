using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace XiADSL.Web
{
    public class BundleToDisk : Bundle
    {
        public override BundleResponse ApplyTransforms(BundleContext context, string bundleContent, IEnumerable<BundleFile> bundleFiles)
        {
            context.UseServerCache = false;
            var res = base.ApplyTransforms(context, bundleContent, bundleFiles);


#if(!DEBUG)
            string physicalPath = context.HttpContext.Request.MapPath("~/app/app.js");
            File.WriteAllText(physicalPath, res.Content);
#endif

            return res;
        }

        public BundleToDisk(string name)
            : base(name)
        {

        }
        
    }

    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));


            var appJs = new BundleToDisk("~/app/app.js")
                .Include("~/App/boot.js")
                .IncludeDirectory("~/App/directive", "*.js")
                .IncludeDirectory("~/App/filter", "*.js")
                .IncludeDirectory("~/App/Service", "*.js")
                .IncludeDirectory("~/App/Controller", "*.js");
            //appJs.Transforms.Add(new BundleDiskDumper("~/app/app.js"));
            bundles.Add(appJs);

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}