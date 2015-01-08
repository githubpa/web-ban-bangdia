using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;          
using  System.IO;

namespace WEBBANGDIA
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["CheckLogin"] = "";
            Session["FullName"] = "bạn!";
            Session["UserName"] = "";
            Session["Home"] = 0;
            Session["AllPro"] = 0;
            Session["LogedFullName"] = "Chào bạn!";
			Session["MaTK"]="";      
            Session["search"] = "";
            Session["Error"] = "";
            Session["Gia"] = "";
            Session["Xem"] = "";
            Session["TheLoai"] = "";
            Session["Hsx"] = "";
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["DangTruyCap"] = 0;
            Session["CheckLogin"] = "";
            Session["FullName"] = "bạn!";
            Session["UserName"] = "";
            Session["Home"] = 0;
            Session["AllPro"] = 0;
            Session["LogedFullName"] = "Chào bạn!";
			Session["MaTK"]="";
            Session["search"] = "";
            Session["Error"] = "";
            Session["Gia"] = "";
            Session["Xem"] = "";
            Session["TheLoai"] = "";
            Session["Hsx"] = "";
        }
    }
}