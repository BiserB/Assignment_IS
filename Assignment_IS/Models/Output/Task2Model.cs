using Assignment_IS.Entities.Task2;
using Assignment_IS.Models.Input;
using System.Collections.Generic;

namespace Assignment_IS.Models.Output
{
    public class Task2Model
    {
        public CreateCarModel CreationModel { get; set; }

        public IReadOnlyCollection<Car> Cars { get; set; } = new List<Car>();

        public IReadOnlyCollection<Car> FragileCars { get; set; } = new List<Car>();

        public IReadOnlyCollection<Car> FlamableCars { get; set; } = new List<Car>();
    }
}
