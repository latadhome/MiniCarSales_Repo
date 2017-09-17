// <copyright file="WebApiConfig.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Web API Configuration
// </summary>

namespace Mini_CarSales.WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    /// <summary>
    /// Web API Configuration
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            log4net.Config.XmlConfigurator.Configure();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
