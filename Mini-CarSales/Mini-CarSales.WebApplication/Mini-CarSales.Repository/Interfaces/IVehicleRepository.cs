// <copyright file="IVehicleRepository.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// IVehicleRepository Interface
// </summary>

namespace Mini_CarSales.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mini_CarSales.Models;

    /// <summary>
    /// IVehicleRepository Interface
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Interface GetAllVehicles
        /// </summary>
        /// <returns> List of Vehicles </returns>
        List<VehicleDetails> GetAllVehicles();

        /// <summary>
        /// Add Vehicle Details
        /// </summary>
        /// <param name="vehicle">Vehicle Details</param>
        /// <returns> Success Status </returns>
        bool AddVehicleDetails(VehicleDetails vehicle);

        /// <summary>
        /// Sample Method To Retrive Data From DB
        /// </summary>
        /// <returns> Data Required</returns>
        Data GetData();
    }
}
