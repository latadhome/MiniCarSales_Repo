// <copyright file="HomeApiController.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Home Api Controller
// </summary>

namespace Mini_CarSales.WebApplication.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// Home API Controller used for Vehicle Operations
    /// </summary>
    public class HomeApiController : ApiController
    {
        /// <summary>
        ///  Sample Test API
        /// </summary>
        /// <param name="name"> Input Name </param>
        /// <returns> customized Hello string</returns>
        [HttpGet]
        public string SampleApi(string name)
        {
            return "Hello : " + name;
        }
    }
}
