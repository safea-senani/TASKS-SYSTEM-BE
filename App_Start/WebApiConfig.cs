﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ticketingSystem_1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //enable cors

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
        //routeTemplate: "api/{controller}/{id}",

        defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
