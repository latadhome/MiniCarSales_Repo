// <copyright file="VehicleService.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// VehicleService
// </summary>

namespace Mini_CarSales.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Repository.Interfaces;

    /// <summary>
    /// Vehicle Service integrating Vehicle Repository and VehicleDetails 
    /// </summary>
    public class VehicleService : IVehicleService
    {
        /// <summary>
        /// Vehicle Repository
        /// </summary>
        private readonly IVehicleRepository vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleService" /> class
        /// </summary>
        /// <param name="ivehicleRepository"> Customer Dashboard Repository</param>
        public VehicleService(IVehicleRepository ivehicleRepository)
        {
            this.vehicleRepository = ivehicleRepository;
        }

        /// <summary>
        /// Get All Vehicle Details
        /// </summary>
        /// <returns> List of Vehicles</returns>
        public List<VehicleDetails> GetAllVehicles()
        {
            List<VehicleDetails> vehiclesList = null;
            try
            {
                vehiclesList = this.vehicleRepository.GetAllVehicles();
            }
            catch (Exception ex)
            {
                throw;
            }

            return vehiclesList;
        }

        /// <summary>
        /// Add Vehicle Details
        /// </summary>
        /// <param name="vehicle"> VehicleDetails Object</param>
        /// <returns> Status Flag </returns>
        public bool AddVehicleDetails(VehicleDetails vehicle)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = this.vehicleRepository.AddVehicleDetails(vehicle);
            }
            catch (Exception ex)
            {
                throw;
            }

            return isSuccess;
        }

        /// <summary>
        /// Sample Method To Retrive Data From DB
        /// </summary>
        /// <returns> Data Required</returns>
        public Data GetData()
        {
            Data data = null;
            try
            {
                data = this.vehicleRepository.GetData();
            }
            catch (Exception ex)
            {
                throw;
            }

            return data;
        }
    }
}
