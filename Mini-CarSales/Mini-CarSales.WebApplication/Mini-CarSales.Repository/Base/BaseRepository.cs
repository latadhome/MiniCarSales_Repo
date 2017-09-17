// <copyright file="BaseRepository.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Base Repository
// </summary>

namespace Mini_CarSales.Repository.Base
{
    using Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base Repository
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// The object which holds the SQL connection
        /// </summary>
        private SqlConnection objSqlConnection = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository" /> class
        /// </summary>
        public BaseRepository()
        {
            this.objSqlConnection = new SqlConnection(ConfigUtil.Instance.ConnectionString);
        }

        /// <summary>
        /// Gets SQL connection object
        /// </summary>
        public SqlConnection GetConnection
        {
            get
            {
                return this.objSqlConnection;
            }
        }

        /// <summary>
        /// Dispose method will close and dispose the connection object that was created earlier.
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (this.objSqlConnection != null && this.objSqlConnection.State != ConnectionState.Closed)
                {
                    this.objSqlConnection.Close();
                    ////this.objSqlConnection.Dispose();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Open method will open the current instance of the connection object if the object is in closed state
        /// </summary>
        public void Open()
        {
            try
            {
                if (this.objSqlConnection != null && this.objSqlConnection.State == ConnectionState.Closed)
                {
                    this.objSqlConnection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// ExecuteNonQueryProcedure is the method by which a Stored Procedure is called with the list of
        /// parameters and its values. This method will execute the stored procedure and returns the status of
        /// on completion. Any exceptions during the process will throws the error.
        /// </summary>
        /// <param name="storedProcName">Name of the Stored Procedure that to be executed  </param>
        /// <param name="parameterList">All required parameters in the Hash table format with the format
        ///                                 - @OUT_ prefix for output parameters
        ///                                 - @IN_ prefix for input parameters  </param>
        /// <returns>The result of the Stored Procedure execution</returns>
        public int ExecuteNonQueryProcedure(string storedProcName, Hashtable parameterList)
        {
            int returnValue = 0;
            int counter = 0;

            try
            {
                SqlCommand objSqlCommand = new SqlCommand(storedProcName, this.objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                if (parameterList != null)
                {
                    foreach (string parametername in parameterList.Keys)
                    {
                        objSqlCommand.Parameters.AddWithValue(parametername, parameterList[parametername]);

                        if (parametername.StartsWith("@OUT_"))
                        {
                            objSqlCommand.Parameters[counter].Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            objSqlCommand.Parameters[counter].Direction = ParameterDirection.Input;
                        }

                        counter++;
                    }
                }

                returnValue = objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return returnValue;
        }
    }
}
