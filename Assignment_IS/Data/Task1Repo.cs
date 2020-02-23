using Assignment_IS.Entities.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Data
{
    public static class Task1Repo
    {
        private static List<Family> Families = new List<Family>();
        private static List<Person> Persons = new List<Person>();

        public static IReadOnlyCollection<Family> GetFamilies()
        {
            return Families.AsReadOnly();
        }

        public static IReadOnlyCollection<Person> GetPersons()
        {
            return Persons.AsReadOnly();
        }

        public static void AddFamily(Family family)
        {
            if (family == null)
            {
                throw new ArgumentNullException("Invalid Family");
            }

            Families.Add(family);
        }

        public static void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Invalid Person");
            }

            Persons.Add(person);
        }

        public static Person GetPerson(Guid personId)
        {
            return Persons.FirstOrDefault(p => p.Id == personId);
        }

        public static Family GetFamily(Guid familyId)
        {
            return Families.FirstOrDefault(f => f.Id == familyId);
        }

        public static void SeedData()
        {
            List<Family> demoFamilies = new List<Family>()
            {
                new Family("Johnson"),
                new Family("Peterson"),
                new Family("MacLeod")
            };

            List<Person> demoPersons = new List<Person>()
            {
                new Person("Duncan", 30),
                new Person("Christopher Lambert", 50),
                new Person("Connor MacLeod", 40)
            };

            foreach (var person in demoPersons)
            {
                Task1Repo.AddPerson(person);
                demoFamilies.Last().AddMember(person);
            }
            
            foreach (var family in demoFamilies)
            {
                Task1Repo.AddFamily(family);
            }
        }
    }
}
