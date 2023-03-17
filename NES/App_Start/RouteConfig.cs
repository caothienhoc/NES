using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NES
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DM_Mau",
                url: "danhmucmau",
                defaults: new { controller = "DM_Mau", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NES.Controllers" }
            );

            routes.MapRoute(
                name: "Account",
                url: "quan-ly-tai-khoan",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NES.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                //url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NES.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NES.Controllers" }
            );
        }
    }
}
