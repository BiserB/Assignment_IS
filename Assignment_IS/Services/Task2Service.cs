using Assignment_IS.Data;
using Assignment_IS.Entities.Task2;
using Assignment_IS.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Services
{
    public class Task2Service
    {
        public IReadOnlyCollection<Car> GetCars()
        {
            return Task2Repo.GetCars();
        }

        public List<Car> GetFragileCars()
        {
            return Task2Repo.GetCars()
                .Where(c => c.Cargo.CargoType.Equals(CargoType.Fragile) && c.Tires.Any(t => t.Presure < 1))
                .ToList();
        }

        public List<Car> GetFlamableCars()
        {
            return Task2Repo.GetCars()
                .Where(c => c.Cargo.CargoType.Equals(CargoType.Flamable) && c.Engine.Power > 250)
                .ToList();
        }

        public void CreateCar(CreateCarModel m)
        {
            Engine engine = new Engine(m.Speed, m.Power);

            CargoType cargoType;

            if (!Enum.TryParse(m.CargoType, true, out cargoType))
            {
                throw new ArgumentException("Invalid cargo type parameter");
            }

            Cargo cargo = new Cargo(m.Weight, cargoType);

            Tire[] tires = new Tire[4];
            tires[0] = new Tire(m.Tire1Presure, m.Tire1Age);
            tires[1] = new Tire(m.Tire2Presure, m.Tire2Age);
            tires[2] = new Tire(m.Tire3Presure, m.Tire3Age);
            tires[3] = new Tire(m.Tire4Presure, m.Tire4Age);

            Car car = new Car(m.Model, engine, cargo, tires);

            Task2Repo.AddCar(car);
        }
    }

}
