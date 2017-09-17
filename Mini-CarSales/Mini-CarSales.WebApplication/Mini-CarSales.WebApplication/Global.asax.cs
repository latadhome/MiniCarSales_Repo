// <copyright file="Global.asax.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Global settings on Startup
// </summary>

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Mini_CarSales.WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.SessionState;
    using Mini_CarSales.WebApplication.App_Start;

    public class Global : HttpApplication
    {
        /// <summary>
        /// Application settings on Start
        /// </summary>
        /// <param name="sender"> sender object</param>
        /// <param name="e"> Event ARGS</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}