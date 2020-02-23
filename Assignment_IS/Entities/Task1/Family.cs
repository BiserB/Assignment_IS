using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment_IS.Entities.Task1
{
    public class Family
    {
        private const string FILE_NOT_FOUND_MSG = "File {0} doesn't exists!";

        public Family(string familyName)
        {
            this.Id = Guid.NewGuid();
            this.FamilyName = familyName;
            this.Members = new List<Person>();
        }

        private List<Person> Members { get; set; }

        public Guid Id { get; private set; }

        private string familyName;

        public string FamilyName
        {
            get
            {
                return familyName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid Family name");
                }
                familyName = value;
            }
        }

        public int MembersCount
        {
            get
            {
                return this.Members.Count;
            }
        }

        public void AddMember(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Can not add NULL member");
            }

            this.Members.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.Members.OrderBy(m => m.Age).LastOrDefault();
        }

        public List<Person> GetMembersOlderThan30()
        {
            return this.Members.Where(m => m.Age > 30).OrderBy(m => m.Age).ToList();
        }

        public void AddMembersFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(String.Format(FILE_NOT_FOUND_MSG, filePath));
            }

            string text = File.ReadAllText(filePath);

            Person[] persons = JsonConvert.DeserializeObject<Person[]>(text);

            foreach (var person in persons)
            {
                this.AddMember(person);
            }
        }
    }
}
