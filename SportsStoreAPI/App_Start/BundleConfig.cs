using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SportsStoreAPI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/store").Include(
                        "~/Scripts/Custom/storeAjax.js",
                        "~/Scripts/Custom/storeModel.js",
                        "~/Scripts/Custom/storeCommonController.js",
                        "~/Scripts/Custom/storeProductsController.js",
                        "~/Scripts/Custom/storeOrdersController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/Site.css"));
        }
    }
}