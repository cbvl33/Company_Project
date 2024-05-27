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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Contact",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "About",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Services",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Services", id = UrlParameter.Optional }

            );
          //routes.MapRoute(
          //    name: "Appointment",
          //    url: "{controller}/{action}/{id}",
          //    defaults: new { controller = "Home", action = "appointment", id = UrlParameter.Optional }
          //
          //);
            routes.MapRoute(
                name: "Pricing",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Pricing", id = UrlParameter.Optional }

            );
            routes.MapRoute(
             name: "User",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "user", id = UrlParameter.Optional }

             );

            routes.MapRoute(
            name: "Team",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Team", id = UrlParameter.Optional }

        );
            routes.MapRoute(
             name: "Testimonials",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Testimonials", id = UrlParameter.Optional }

         );
            //     routes.MapRoute(
            //    name: "appoitment",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "appointment", id = UrlParameter.Optional }
            //
            //);
            //   routes.MapRoute(
            //    name: "Team",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Team", id = UrlParameter.Optional }
            //
            //);
            routes.MapRoute(
                name: "SignIn",
                url: "Home/SignIn", // Уникальный путь для входа
                defaults: new { controller = "Login", action = "SignIn" }
                );

            routes.MapRoute(
                name: "SignUp",
                url: "Home/SignUp", // Уникальный путь для регистрации
                defaults: new { controller = "Login", action = "SignUp" }
            );


        }
    }
}