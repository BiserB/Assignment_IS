using Assignment_IS.Entities.Task1;
using System.Collections.Generic;

namespace Assignment_IS.Models.Output
{
    public class Task1Model
    {
        public IReadOnlyCollection<Family> Families { get; set; } = new List<Family>();

        public IReadOnlyCollection<Person> Persons { get; set; } = new List<Person>();

        public IReadOnlyCollection<Person> OlderThanThirty { get; set; } = new List<Person>();
    }
}
