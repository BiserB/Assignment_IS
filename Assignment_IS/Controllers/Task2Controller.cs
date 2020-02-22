
using Assignment_IS.Models.Input;
using Assignment_IS.Models.Output;
using Assignment_IS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_IS.Controllers
{
    public class Task2Controller : Controller
    {
        private readonly Task2Service task2Service;

        public Task2Controller(Task2Service task2Service)
        {
            this.task2Service = task2Service;
        }

        public IActionResult Index()
        {
            Task2Model model = new Task2Model();

            model.Cars = this.task2Service.GetCars();
            model.FragileCars = this.task2Service.GetFragileCars();
            model.FlamableCars = this.task2Service.GetFlamableCars();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCar(CreateCarModel inputModel)
        {
            if (ModelState.IsValid)
            {
                this.task2Service.CreateCar(inputModel);
            }

            return LocalRedirect("/task2/index");
        }
    }
}