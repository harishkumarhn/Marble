using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Marbale.ManagementStudio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //// Code that runs on application startup
            //System.Timers.Timer myTimer = new System.Timers.Timer();
            //// Set the Interval to 5 seconds (5000 milliseconds).
            //myTimer.Interval = 47000;
            //myTimer.AutoReset = true;
            //myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            //myTimer.Enabled = true;
        }
        //public void myTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        //{
        //    SiteSetupController s = new SiteSetupController();
        //    HttpPostedFileBase fileUploader = null;
        //    HttpPostedFileBase fileUploader1 = null;
        //    //  s.email_send( fileUploader,fileUploader1);
        //}
    }
}
