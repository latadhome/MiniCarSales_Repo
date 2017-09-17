using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_CarSales.Models
{
    public class Data
    {
        public List<Vehicle> VehicleTypes { get; set; }

        public List<Manufacturer> Makes { get; set; }

        public List<Model> Models { get; set; }

        public List<Engine> Engines { get; set; }
    }

    public class Vehicle
    {
        public int Id { get; set; }

        public string VehicleType { get; set; }
    }

    public class Manufacturer
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int VehicleId { get; set; }

    }

    public class Model
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public int VehicleId { get; set; }

    }

    public class Engine
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int ModelId { get; set; }
    }

}
