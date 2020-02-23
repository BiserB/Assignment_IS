using Assignment_IS.Models.Input;
using Assignment_IS.Models.Output;
using Assignment_IS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_IS.Controllers
{
    public class Task1Controller : Controller
    {
        private readonly Task1Service task1Service;

        public Task1Controller(Task1Service task1Service)
        {
            this.task1Service = task1Service;
        }

        public IActionResult Index()
        {
            Task1Model model = new Task1Model();

            model.Families = this.task1Service.GetAllFamilies();
            model.Persons = this.task1Service.GetAllPersons();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateFamily(CreateFamilyModel inputModel)
        {
            if (ModelState.IsValid)
            {
                this.task1Service.CreateNewFamily(inputModel);
            }

            return LocalRedirect("/Task1/Index");
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonModel inputModel)
        {
            this.task1Service.CreateNewPerson(inputModel);

            return LocalRedirect("/Task1/Index");
        }

        [HttpGet]
        public IActionResult GetAllOverThirty()
        {
            Task1Model model = new Task1Model();

            model.Families = this.task1Service.GetAllFamilies();
            model.Persons = this.task1Service.GetAllPersons();
            model.OlderThanThirty = this.task1Service.GetOlderThanThirty();

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult AddFromFile()
        {
            this.task1Service.AddPersonsFromFile();

            return LocalRedirect("/Task1/Index");
        }
        
        public IActionResult AddMember(AddMemberModel inputModel)
        {
            if (ModelState.IsValid)
            {
                this.task1Service.AddMember(inputModel);
            }

            return LocalRedirect("/Task1/Index");
        }
    }
}