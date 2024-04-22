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
            // Игнорирование запросов к файлам ресурсов
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Добавление маршрута для LoginAction в LoginController
            routes.MapRoute(
                name: "LoginAction",
                url: "Login/LoginAction",
                defaults: new { controller = "Login", action = "LoginAction" }
            );

            // Добавление маршрута для RegisterAction в LoginController
            routes.MapRoute(
                name: "RegisterAction",
                url: "Login/RegisterAction",
                defaults: new { controller = "Login", action = "RegisterAction" }
            );

            // Маршрут по умолчанию
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

