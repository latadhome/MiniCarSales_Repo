// <copyright file="VehicleApiController.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// VehicleApiController For Getting List of Vehicles, Adding new Vehicle and Editing New Vehicle
// </summary>

namespace Mini_CarSales.WebApplication.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using log4net;
    using Models;
    using Service.Interfaces;
    using System.Web.Http.ModelBinding;

    /// <summary>
    /// Used For Getting List of Vehicles, Adding new Vehicle and Editing New Vehicle
    /// </summary>
    public class VehicleApiController : ApiController
    {
        /// <summary>
        /// Create Logger Object
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Vehicle Service
        /// </summary>
        private readonly IVehicleService vehicleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleApiController" /> class
        /// </summary>
        /// <param name="ivehicleService"> Vehicle Service</param>
        public VehicleApiController(IVehicleService ivehicleService)
        {
            this.vehicleService = ivehicleService;
        }

        /// <summary>
        /// Get All Vehicles
        /// </summary>
        /// <returns> List Of Vehicles</returns>
        [HttpGet]
        public List<VehicleDetails> GetAllVehicles()
        {
            List<VehicleDetails> vehiclesList = null;
            try
            {
                vehiclesList = this.vehicleService.GetAllVehicles();
            }
            catch (Exception ex)
            {
                Log.Error("GetAllVehicles :" + ex.Message);
            }

            return vehiclesList;
        }

        /// <summary>
        /// Add Vehicle Details
        /// </summary>
        /// <param name="vehicle"> VehicleDetails Model</param>
        /// <returns> Insertion Status</returns>
        [HttpPost]
        public bool AddVehicleDetails([FromBody]VehicleDetails vehicle)
        {
            bool isSuccessCreate = false;
            ////Validate Input Vehicle Details against Required feilds of VehicleDetails Model
            if (this.ModelState.IsValid)
            {
                try
                {
                    isSuccessCreate = this.vehicleService.AddVehicleDetails(vehicle);
                }
                catch (Exception ex)
                {
                    Log.Error("AddVehicleDetails :" + ex.Message);
                    isSuccessCreate = false;
                }
            }
            else
            {
                string message = null;
                foreach (ModelState modelState in this.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        message = message + error.ErrorMessage;
                    }
                }

                Log.Error("AddVehicleDetails :" + message);
            }

            return isSuccessCreate;
        }
    }
}
