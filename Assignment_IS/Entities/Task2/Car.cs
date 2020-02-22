using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Entities.Task2
{
    public class Car
    {
        private const int TIRES_COUNT = 4;
        private Tire[] tires = new Tire[TIRES_COUNT];

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Id = Guid.NewGuid();
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public Guid Id { get; private set; }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public Tire[] Tires
        {
            get { return tires; }

            set
            {
                if (value.Length != TIRES_COUNT)
                {
                    throw new ArgumentException("Invalid count of tires");
                }

                for (int i = 0; i < value.Length; i++)
                {
                    this.tires[i] = new Tire(value[i].Presure, value[i].Age);
                }
            }
        }

    }
}
