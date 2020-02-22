using System;

namespace Assignment_IS.Entities.Task1
{
    public class Person
    {
        private const string DEFAULT_NAME = "No Name";
        private const int DEFAULT_AGE = 1;

        public Person(): this(DEFAULT_NAME, DEFAULT_AGE)
        { }

        public Person(int age): this(DEFAULT_NAME, age)
        { }

        public Person(string name, int age)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Age = age;
        }
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
