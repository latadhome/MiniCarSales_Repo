// <copyright file="IVehicleService.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// IVehicleService Interface
// </summary>

namespace Mini_CarSales.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// IVehicleService Interface
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Interface GetAllVehicles
        /// </summary>
        /// <returns> List of Vehicles </returns>
        List<VehicleDetails> GetAllVehicles();

        /// <summary>
        /// Add Vehicle Details
        /// </summary>
        /// <param name="vehicle">Vehicle Details </param>
        /// <returns> Status Indicator</returns>
        bool AddVehicleDetails(VehicleDetails vehicle);

        /// <summary>
        /// Sample Method To Retrive Data From DB
        /// </summary>
        /// <returns> Data Required</returns>
        Data GetData();
    }
}
