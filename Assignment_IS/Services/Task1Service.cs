using Assignment_IS.Data;
using Assignment_IS.Entities.Task1;
using Assignment_IS.Models.Input;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment_IS.Services
{
    public class Task1Service
    {
        private const string PERSONS_FILEPATH = "\\FileRepo\\Persons.json";
        private readonly IHostingEnvironment hostingEnvironment;

        public Task1Service(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public IReadOnlyCollection<Family> GetAllFamilies()
        {
            return Task1Repo.GetFamilies();
        }

        public IReadOnlyCollection<Person> GetAllPersons()
        {
            return Task1Repo.GetPersons();
        }

        public void CreateNewFamily(CreateFamilyModel model)
        {
            Family newFamily = new Family(model.FamilyName);

            Task1Repo.AddFamily(newFamily);
        }

        public void CreateNewPerson(CreatePersonModel model)
        {
            Person newPerson = null;

            if (model.Age != 0 && !String.IsNullOrWhiteSpace(model.Name))
            {
                newPerson = new Person(model.Name, model.Age);
            }
            else if (model.Age != 0)
            {
                newPerson = new Person(model.Age);
            }
            else
            {
                newPerson = new Person();
            }

            Task1Repo.AddPerson(newPerson);
        }

        public List<Person> GetOlderThanThirty()
        {
            return Task1Repo.GetPersons().Where(p => p.Age > 30).ToList();
        }

        public void AddPersonsFromFile()
        {
            string rootPath = this.hostingEnvironment.ContentRootPath;

            string fullPath = rootPath + PERSONS_FILEPATH;

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("File not found at " + fullPath);
            }

            string text = File.ReadAllText(fullPath);

            Person[] persons = JsonConvert.DeserializeObject<Person[]>(text);

            foreach (var person in persons)
            {
                Task1Repo.AddPerson(person);
            }
        }
    }
}
