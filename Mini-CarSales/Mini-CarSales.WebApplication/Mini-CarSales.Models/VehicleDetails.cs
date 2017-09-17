// <copyright file="VehicleDetails.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Vehicle Details
// </summary>

namespace Mini_CarSales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Details of the Vehicle
    /// </summary>
    public class VehicleDetails
    {
        /// <summary>
        /// Gets or sets Id of Individual Vehicle
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Type Id
        /// </summary>
        public int VehicleTypeId { get; set; }

        /// <summary>
        /// Gets or sets Vehicle Type (Car,Bike,..etc)
        /// </summary>
        public string VehicleType { get; set; }

        /// <summary>
        /// Gets or sets Manufacturer Id
        /// </summary>
        public int MakeId { get; set; }

        /// <summary>
        /// Gets or sets Manufacturer Name
        /// </summary>
        [Required]
        public string MakeName { get; set; }

        /// <summary>
        /// Gets or sets Model Id
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// Gets or sets Model Name
        /// </summary>
        [Required]
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets Engine Id
        /// </summary>
        public int EngineId { get; set; }

        /// <summary>
        /// Gets or sets Engine Name
        /// </summary>
        [Required]
        public string EngineName { get; set; }

        /// <summary>
        /// Gets or sets No of Doors
        /// </summary>
        public int Doors { get; set; }

        /// <summary>
        /// Gets or sets No of Wheels
        /// </summary>
        [Required]
        public int Wheels { get; set; }

        /// <summary>
        /// Gets or sets Type (SUV,Sedan,..etc)
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Image Details for given Vehicle
        /// </summary>
        public string ImagePath { get; set; }
    }
}
