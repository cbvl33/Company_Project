using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Contact",
                url: "Home/Contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "About",
                url: "Home/About",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "Services",
                url: "Home/Services",
                defaults: new { controller = "Home", action = "Services", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "Pricing",
                url: "Home/Pricing",
                defaults: new { controller = "Home", action = "Pricing", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "User",
                url: "Home/User",
                defaults: new { controller = "Home", action = "User", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "Team",
                url: "Home/Team",
                defaults: new { controller = "Home", action = "Team", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "Testimonials",
                url: "Home/Testimonials",
                defaults: new { controller = "Home", action = "Testimonials", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "SignIn",
                url: "Home/SignIn",
                defaults: new { controller = "Login", action = "SignIn" },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            routes.MapRoute(
                name: "SignUp",
                url: "Home/SignUp",
                defaults: new { controller = "Login", action = "SignUp" },
                namespaces: new[] { "WebApplication1.Controllers" }
            );

            // Оставляем маршрут по умолчанию в конце, чтобы он использовался, если нет совпадений
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication1.Controllers" }
            );
        }
    }
}
