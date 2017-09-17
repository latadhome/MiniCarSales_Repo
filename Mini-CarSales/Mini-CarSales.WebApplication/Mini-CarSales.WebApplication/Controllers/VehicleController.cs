// <copyright file="VehicleController.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Vehicle Controller 
// </summary>

namespace Mini_CarSales.WebApplication.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Vehicle Controller For Creating and Editing Vehicle
    /// </summary>
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult CreateVehicle()
        {
            return View();
        }
    }
}