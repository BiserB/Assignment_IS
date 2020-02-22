using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Entities.Task2
{
    public class Cargo
    {
        public Cargo(int weight, CargoType cargoType)
        {
            this.Weight = weight;
            this.CargoType = cargoType;
        }

        public int Weight { get; private set; }

        public CargoType CargoType { get; private set; }
    }
}
