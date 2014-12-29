using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEBBANGDIA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
              "RouteIndexNon",
              "trang-chu",
              new
              {
                  controller = "Home",
                  action = "Index",
              }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "WEBBANGDIA" }
            );
            routes.MapRoute(
                "RouteAll",
                "{idDm}/TenDm-{TenDanhMuc}",
                new
                {
                    controller = "Home",
                    action = "All",
                    id = "idDm"
                }
            );
        }
    }
}