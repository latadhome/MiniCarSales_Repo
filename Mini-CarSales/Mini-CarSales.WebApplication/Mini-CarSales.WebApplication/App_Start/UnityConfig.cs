// <copyright file="UnityConfig.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Unity Register Components Configuration
// </summary>

namespace Mini_CarSales.WebApplication.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using Repository;
    using Repository.Interfaces;
    using Service;
    using Service.Interfaces;
    using Unity.Mvc5;

    /// <summary>
    /// Unity Register Components Configuration
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Register All Required Components
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IVehicleService, VehicleService>();
            container.RegisterType<IVehicleRepository, VehicleRepository>();

           // DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}