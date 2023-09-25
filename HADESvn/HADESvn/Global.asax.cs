using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace HADESvn
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Session["admin"] = false;
            Session["TENADMIN"] = null;
            Session["user"] = false;                   
            Session["Cart"] = null;
            Session["MAND"] = null;
            Session["TENND"] = null;
            Session["SDT"] = null;
            Session["EMAIL"] = null;
            Session["DIACHI"] = null;
        }
    }
}