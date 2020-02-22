using Assignment_IS.Entities.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Data
{
    public static class Task2Repo
    {
        private static List<Car> Cars = new List<Car>();

        public static IReadOnlyCollection<Car> GetCars()
        {
            return Cars.AsReadOnly();
        }

        public static void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("Invalid Car");
            }

            Cars.Add(car);
        }

        public static void SeedData()
        {
            Engine engine1 = new Engine(250, 145);
            Engine engine2 = new Engine(130, 270);

            Cargo cargo1 = new Cargo(2000, CargoType.Fragile);
            Cargo cargo2 = new Cargo(3000, CargoType.Flamable);

            Tire[] tires = new Tire[4];
            tires[0] = new Tire(2.2, 2);
            tires[1] = new Tire(2.2, 2);
            tires[2] = new Tire(2.4, 0);
            tires[3] = new Tire(0.9, 4);

            Car demoCar1 = new Car("Demo car", engine1, cargo1, tires);
            Car demoCar2 = new Car("ZIL-131", engine2, cargo2, tires);

            AddCar(demoCar1);
            AddCar(demoCar2);
        }
    }
}
