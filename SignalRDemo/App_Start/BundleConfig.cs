using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SignalRDemo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/signalR").Include(
                "~/Scripts/jquery.signalR-2.0.1.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/kinetic").Include(
                "~/Scripts/kinetic-v{version}.js"));
        }
    }
}