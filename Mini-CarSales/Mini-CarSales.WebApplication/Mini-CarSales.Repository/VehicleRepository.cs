// <copyright file="VehicleRepository.cs" company="carsales.com.au">
// Copyright (c) carsales.com.au. All rights reserved.
// </copyright>
// <summary>
// Vehicle Repository
// </summary>

namespace Mini_CarSales.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Mini_CarSales.Models;

    /// <summary>
    /// Vehicle Repository for DB Oprations
    /// </summary>
    public class VehicleRepository : Base.BaseRepository, IVehicleRepository
    {
        /// <summary>
        /// Get All Vehicles
        /// </summary>
        /// <returns> List Of Vehicles</returns>
        public List<VehicleDetails> GetAllVehicles()
        {
            List<VehicleDetails> vehicleItemList = null;
            VehicleDetails vehicleItem = null;

            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand("getAllVehicles", this.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                //// cmd.Parameters.Add(new SqlParameter("@UserId", userId));

                using (SqlDataReader userReader = cmd.ExecuteReader())
                {
                    if (userReader.HasRows)
                    {
                        vehicleItemList = new List<VehicleDetails>();

                        int idOrdinal = userReader.GetOrdinal("Id");
                        int vehicleIDOrdinal = userReader.GetOrdinal("VehicleID");
                        int vehicleTypeOrdinal = userReader.GetOrdinal("VehicleType");
                        int makeIdOrdinal = userReader.GetOrdinal("MakeId");
                        int makeNameOrdinal = userReader.GetOrdinal("MakeName");
                        int modelIdOrdinal = userReader.GetOrdinal("ModelId");
                        int modelNameOrdinal = userReader.GetOrdinal("ModelName");
                        int engineIdOrdinal = userReader.GetOrdinal("EngineId");
                        int engineNameOrdinal = userReader.GetOrdinal("EngineName");
                        int doorsOrdinal = userReader.GetOrdinal("Doors");
                        int wheelsOrdinal = userReader.GetOrdinal("Wheels");
                        int typeOrdinal = userReader.GetOrdinal("Type");
                        int imagePathOrdinal = userReader.GetOrdinal("ImagePath");

                        while (userReader.Read())
                        {
                            vehicleItem = new VehicleDetails();
                            if (!userReader.IsDBNull(idOrdinal))
                            {
                                vehicleItem.Id = userReader.GetInt32(idOrdinal);
                            }

                            if (!userReader.IsDBNull(vehicleIDOrdinal))
                            {
                                vehicleItem.VehicleTypeId = userReader.GetInt32(vehicleIDOrdinal);
                            }

                            if (!userReader.IsDBNull(vehicleTypeOrdinal))
                            {
                                vehicleItem.VehicleType = userReader.GetString(vehicleTypeOrdinal);
                            }

                            if (!userReader.IsDBNull(makeIdOrdinal))
                            {
                                vehicleItem.MakeId = userReader.GetInt32(makeIdOrdinal);
                            }

                            if (!userReader.IsDBNull(makeNameOrdinal))
                            {
                                vehicleItem.MakeName = userReader.GetString(makeNameOrdinal);
                            }

                            if (!userReader.IsDBNull(modelIdOrdinal))
                            {
                                vehicleItem.ModelId = userReader.GetInt32(modelIdOrdinal);
                            }

                            if (!userReader.IsDBNull(modelNameOrdinal))
                            {
                                vehicleItem.ModelName = userReader.GetString(modelNameOrdinal);
                            }

                            if (!userReader.IsDBNull(engineIdOrdinal))
                            {
                                vehicleItem.EngineId = userReader.GetInt32(engineIdOrdinal);
                            }

                            if (!userReader.IsDBNull(engineNameOrdinal))
                            {
                                vehicleItem.EngineName = userReader.GetString(engineNameOrdinal);
                            }

                            if (!userReader.IsDBNull(doorsOrdinal))
                            {
                                vehicleItem.Doors = userReader.GetInt32(doorsOrdinal);
                            }
                            if (!userReader.IsDBNull(wheelsOrdinal))
                            {
                                vehicleItem.Wheels = userReader.GetInt32(wheelsOrdinal);
                            }

                            if (!userReader.IsDBNull(typeOrdinal))
                            {
                                vehicleItem.Type = userReader.GetString(typeOrdinal);
                            }

                            if (!userReader.IsDBNull(imagePathOrdinal))
                            {
                                vehicleItem.ImagePath = userReader.GetString(imagePathOrdinal);

                                if (vehicleItem.ImagePath == string.Empty)
                                {
                                    vehicleItem.ImagePath = "~/Images/DefaultBike.jpg";
                                }
                            }
                            else
                            {
                                vehicleItem.ImagePath = "~/Images/DefaultBike.jpg";
                            }

                            vehicleItemList.Add(vehicleItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.Dispose();
            }

            return vehicleItemList;
        }

        /// <summary>
        /// Add Vehicle Details
        /// </summary>
        /// <param name="vehicle"> Vehicle Details</param>
        /// <returns> Operation Status</returns>
        public bool AddVehicleDetails(VehicleDetails vehicle)
        {
            bool isSuccess = false;
            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand("addVehicleDetails", this.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (vehicle.VehicleTypeId != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@VehicleID", vehicle.VehicleTypeId));
                    cmd.Parameters.Add(new SqlParameter("@VehicleType", vehicle.VehicleType));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@VehicleType", vehicle.VehicleType));
                }

                if (vehicle.MakeId != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@MakeID", vehicle.MakeId));
                    cmd.Parameters.Add(new SqlParameter("@MakeName", vehicle.MakeName));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@MakeName", vehicle.MakeName));
                }

                if (vehicle.ModelId != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@ModelID", vehicle.ModelId));
                    cmd.Parameters.Add(new SqlParameter("@ModelName", vehicle.ModelName));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@ModelName", vehicle.ModelName));
                }

                if (vehicle.EngineId != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@EngineID", vehicle.EngineId));
                    cmd.Parameters.Add(new SqlParameter("@EngineName", vehicle.EngineName));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@EngineName", vehicle.EngineName));
                }

                    cmd.Parameters.Add(new SqlParameter("@Doors", vehicle.Doors));
                    cmd.Parameters.Add(new SqlParameter("@Wheels", vehicle.Wheels));
                    cmd.Parameters.Add(new SqlParameter("@Type", vehicle.Type));

                if (vehicle.ImagePath != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@ImagePath", vehicle.ImagePath));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@ImagePath", "~/Images/Default" + vehicle.VehicleType + ".jpg"));
                }

                int count;
                count = cmd.ExecuteNonQuery();
                if (count >= 1)
                {
                    isSuccess = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Dispose();
            }

            return isSuccess;
        }

        /// <summary>
        /// Update Vehicle Details
        /// </summary>
        /// <param name="vehicle"> Vehicle Details</param>
        /// <returns> Operation Status</returns>
        public bool UpdateVehicle(VehicleDetails vehicle)
        {
            bool isSuccess = false;
            string sqlQuery = string.Empty;
            try
            {
                this.Open();
                if (vehicle.VehicleType == "Car")
                {
                    sqlQuery = "Update VehicleDetails set Doors=" + vehicle.Doors + ",Wheels=" + vehicle.Wheels + ",Type='" + vehicle.Type + "' where Id = " + vehicle.Id;
                }
                else
                {
                    sqlQuery = "Update VehicleDetails set Wheels=" + vehicle.Wheels + ",Type='" + vehicle.Type + "' where Id = " + vehicle.Id;
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, this.GetConnection);

                int count;
                count = cmd.ExecuteNonQuery();
                if (count >= 1)
                {
                    isSuccess = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Dispose();
            }

            return isSuccess;
        }

        /// <summary>
        /// Get Vehicle Details
        /// </summary>
        /// <param name="id">Vehicle id</param>
        /// <returns> Success Status </returns>
        public VehicleDetails GetVehicleDetails(int id)
        {
            VehicleDetails vehicleItem = null;

            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand("getVehicle", this.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                using (SqlDataReader userReader = cmd.ExecuteReader())
                {
                    if (userReader.HasRows)
                    {
                        vehicleItem = new VehicleDetails();

                        int idOrdinal = userReader.GetOrdinal("Id");
                        int vehicleIDOrdinal = userReader.GetOrdinal("VehicleID");
                        int vehicleTypeOrdinal = userReader.GetOrdinal("VehicleType");
                        int makeIdOrdinal = userReader.GetOrdinal("MakeId");
                        int makeNameOrdinal = userReader.GetOrdinal("MakeName");
                        int modelIdOrdinal = userReader.GetOrdinal("ModelId");
                        int modelNameOrdinal = userReader.GetOrdinal("ModelName");
                        int engineIdOrdinal = userReader.GetOrdinal("EngineId");
                        int engineNameOrdinal = userReader.GetOrdinal("EngineName");
                        int doorsOrdinal = userReader.GetOrdinal("Doors");
                        int wheelsOrdinal = userReader.GetOrdinal("Wheels");
                        int typeOrdinal = userReader.GetOrdinal("Type");
                        int imagePathOrdinal = userReader.GetOrdinal("ImagePath");

                        while (userReader.Read())
                        {
                            if (!userReader.IsDBNull(idOrdinal))
                            {
                                vehicleItem.Id = userReader.GetInt32(idOrdinal);
                            }

                            if (!userReader.IsDBNull(vehicleIDOrdinal))
                            {
                                vehicleItem.VehicleTypeId = userReader.GetInt32(vehicleIDOrdinal);
                            }

                            if (!userReader.IsDBNull(vehicleTypeOrdinal))
                            {
                                vehicleItem.VehicleType = userReader.GetString(vehicleTypeOrdinal);
                            }

                            if (!userReader.IsDBNull(makeIdOrdinal))
                            {
                                vehicleItem.MakeId = userReader.GetInt32(makeIdOrdinal);
                            }

                            if (!userReader.IsDBNull(makeNameOrdinal))
                            {
                                vehicleItem.MakeName = userReader.GetString(makeNameOrdinal);
                            }

                            if (!userReader.IsDBNull(modelIdOrdinal))
                            {
                                vehicleItem.ModelId = userReader.GetInt32(modelIdOrdinal);
                            }

                            if (!userReader.IsDBNull(modelNameOrdinal))
                            {
                                vehicleItem.ModelName = userReader.GetString(modelNameOrdinal);
                            }

                            if (!userReader.IsDBNull(engineIdOrdinal))
                            {
                                vehicleItem.EngineId = userReader.GetInt32(engineIdOrdinal);
                            }

                            if (!userReader.IsDBNull(engineNameOrdinal))
                            {
                                vehicleItem.EngineName = userReader.GetString(engineNameOrdinal);
                            }

                            if (!userReader.IsDBNull(doorsOrdinal))
                            {
                                vehicleItem.Doors = userReader.GetInt32(doorsOrdinal);
                            }
                            if (!userReader.IsDBNull(wheelsOrdinal))
                            {
                                vehicleItem.Wheels = userReader.GetInt32(wheelsOrdinal);
                            }

                            if (!userReader.IsDBNull(typeOrdinal))
                            {
                                vehicleItem.Type = userReader.GetString(typeOrdinal);
                            }

                            if (!userReader.IsDBNull(imagePathOrdinal))
                            {
                                vehicleItem.ImagePath = userReader.GetString(imagePathOrdinal);

                                if (vehicleItem.ImagePath == string.Empty)
                                {
                                    vehicleItem.ImagePath = "~/Images/DefaultBike.jpg";
                                }
                            }
                            else
                            {
                                vehicleItem.ImagePath = "~/Images/DefaultBike.jpg";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.Dispose();
            }

            return vehicleItem;

        }

        /// <summary>
        /// Sample Method To Retrive Data From DB
        /// </summary>
        /// <returns> Data Required</returns>
        public Data GetData()
        {
            Data data = new Data();

            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand("select * from Vehicle", this.GetConnection);

                using (SqlDataReader userReader = cmd.ExecuteReader())
                {
                    List<Vehicle> vehicleTypeList = new List<Vehicle>();
                    if (userReader.HasRows)
                    {
                        while (userReader.Read())
                        {
                            Vehicle vehicleItem = new Vehicle();
                            vehicleItem.Id = (int)userReader["Id"];
                            vehicleItem.VehicleType = userReader["VehicleType"].ToString();
                            vehicleTypeList.Add(vehicleItem);
                        }
                    }

                    data.VehicleTypes = vehicleTypeList;
                }

                //// Manufacturers

                SqlCommand makecmd = new SqlCommand("select * from Manufacturer", this.GetConnection);

                using (SqlDataReader userReader = makecmd.ExecuteReader())
                {
                    List<Manufacturer> makeList = new List<Manufacturer>();
                    if (userReader.HasRows)
                    {
                        while (userReader.Read())
                        {
                            Manufacturer makeItem = new Manufacturer();
                            makeItem.Id = (int)userReader["Id"];
                            makeItem.Name = userReader["Name"].ToString();
                            makeItem.VehicleId = (int)userReader["VehicleId"];
                            makeList.Add(makeItem);
                        }
                    }

                    data.Makes = makeList;
                }

                //// Models

                SqlCommand modelcmd = new SqlCommand("select * from Model", this.GetConnection);

                using (SqlDataReader userReader = modelcmd.ExecuteReader())
                {
                    List<Model> modelList = new List<Model>();
                    if (userReader.HasRows)
                    {
                        while (userReader.Read())
                        {
                            Model modelItem = new Model();
                            modelItem.Id = (int)userReader["Id"];
                            modelItem.Name = userReader["Name"].ToString();
                            modelItem.MakeId = (int)userReader["MakeId"];
                            modelItem.VehicleId = (int)userReader["VehicleId"];
                            modelList.Add(modelItem);
                        }
                    }

                    data.Models = modelList;
                }

                //// Engines

                SqlCommand enginecmd = new SqlCommand("select * from Engine", this.GetConnection);

                using (SqlDataReader userReader = enginecmd.ExecuteReader())
                {
                    List<Engine> engineList = new List<Engine>();
                    if (userReader.HasRows)
                    {
                        while (userReader.Read())
                        {
                            Engine engineItem = new Engine();
                            engineItem.Id = (int)userReader["Id"];
                            engineItem.Name = userReader["Name"].ToString();
                            engineItem.ModelId = (int)userReader["ModelId"];
                            engineList.Add(engineItem);
                        }
                    }

                    data.Engines = engineList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.Dispose();
            }

            return data;
        }
    }
}
