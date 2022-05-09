using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UnderstandingURLRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route demoRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("DemoRoute", demoRoute);

            //routes.MapRoute(
            //    name: "Default2",
            //    url: "Customer/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = 10 }
            //    );

            //routes.MapRoute(
            //    name: "Default3",
            //    url: "Customer{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = 10 }
            //    );

            //routes.MapRoute(
            //    name: "Default3",
            //    url: "Customer{controller}/Get{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = 10 }
            //    );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}/{*catchAll}",
            //    defaults: new { controller = "Home", action = "Index", id = 10 }
            //    );


            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "UnderstandingURLRouting2.Controllers" }
            //);

            // routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    constraints: new { action = "Index|About" }
            //);

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults:    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            constraints: new { action = "Index|About|Contact", httpMethod=new HttpMethodConstraint("GET")}
            );



        }
    }
}
