// <copyright file="ConfigUtil.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// ConfigUtil
// </summary>


namespace Mini_CarSales.Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Singleton class to get values from config file for Mini-CarSales Specific DB
    /// </summary>
    public class ConfigUtil
    {
        /// <summary>
        /// Configuration instance
        /// </summary>
        private static ConfigUtil instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="ConfigUtil" /> class from being created
        /// </summary>
        private ConfigUtil()
        {
            this.PopulateConfigSettings();
        }

        /// <summary>
        /// Gets Configuration instance
        /// </summary>
        public static ConfigUtil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigUtil();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets ConnectionString
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets Config Settings For Mini-CarSales Specific DB
        /// </summary>
        private void PopulateConfigSettings()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["Mini-CarSalesContext"].ConnectionString;
        }
    }
}
