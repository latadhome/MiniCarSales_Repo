using log4net;
using Mini_CarSales.Models;
using Mini_CarSales.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
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
        /// Initializes a new instance of the <see cref="HomeController" /> class
        /// </summary>
        /// <param name="ivehicleService"> Vehicle Service</param>
        public HomeController(IVehicleService ivehicleService)
        {
            this.vehicleService = ivehicleService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //List<VehicleDetails> vehiclesList = null;
            //try
            //{
            //    vehiclesList = this.vehicleService.GetAllVehicles();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error("GetAllVehicles :" + ex.Message);
            //}

            return View();
        }

        public ActionResult GetVehicle(int id)
        {
            VehicleDetails vehicle = null;
            try
            {
                vehicle = this.vehicleService.GetVehicleDetails(id);
            }
            catch (Exception ex)
            {
                Log.Error("GetVehicleDetails :" + ex.Message);
            }

            return View(vehicle);
        }

        public PartialViewResult LoadVehicles(string vehTypeId)
        {
            List<VehicleDetails> vehiclesList = null;
            try
            {
                vehiclesList = this.vehicleService.GetAllVehicles();
                if (vehTypeId != "All" && vehTypeId != string.Empty)
                {
                    //List<VehicleDetails> l1 = vehiclesList.Select(s => s.VehicleType == vehTypeId);
                    var l2 = vehiclesList.Select(s => s.VehicleType == vehTypeId);
                    var a = from v in vehiclesList
                            where v.VehicleType == vehTypeId
                            select v;
                    vehiclesList = a.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAllVehicles :" + ex.Message);
            }

            return PartialView(vehiclesList);
        }

        /// <summary>
        /// Sample Method To Retrive Data From DB
        /// </summary>
        /// <returns> Data Required</returns>
        public ActionResult GetData()
        {
            Data data = null;
            try
            {
                data = this.vehicleService.GetData();
            }
            catch (Exception ex)
            {
                Log.Error("GetData :" + ex.Message);
            }

            ////return data;
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Save Vehicle Changes
        /// </summary>
        /// <param name="vh"> Vehicle Details</param>
        /// <returns> Home Screen</returns>
        [HttpPost]
        public ActionResult GetVehicle(VehicleDetails vh)
        {
            bool isSuccessCreate = false;
            try
            {
                isSuccessCreate = this.vehicleService.UpdateVehicle(vh);
            }
            catch (Exception ex)
            {
                Log.Error("Update Vehicle :" + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
