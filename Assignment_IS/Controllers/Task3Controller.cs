using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_IS.Entities.Task3;
using Assignment_IS.Models.Input;
using Assignment_IS.Models.Output;
using Assignment_IS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_IS.Controllers
{
    public class Task3Controller : Controller
    {
        private readonly Task3Service task3Service;

        public Task3Controller(Task3Service task3Service)
        {
            this.task3Service = task3Service;
        }

        public IActionResult Login()
        {
            Task3Model model = new Task3Model();

            model.Users = this.task3Service.GetUsers();
            User currentUser = this.task3Service.GetCurrentUser();

            if (currentUser != null && currentUser.IsLoggedIn)
            {
                model.CurrentUser = currentUser;
                model.ToDoLists = this.task3Service.GetTodoLists(currentUser);
                model.Archived = this.task3Service.GetArchivedTodoLists(currentUser);
            }            

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginUserModel inputModel)
        {
            User currentUser = null;

            if (ModelState.IsValid)
            {
                currentUser = this.task3Service.SignIn(inputModel.Username, inputModel.Password);
            }

            Task3Model model = new Task3Model();

            model.Users = this.task3Service.GetUsers();
            model.CurrentUser = currentUser;
            model.ToDoLists = this.task3Service.GetTodoLists(currentUser);
            model.Archived = this.task3Service.GetArchivedTodoLists(currentUser);

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout(string id)
        {
            this.task3Service.Logout(id);

            return LocalRedirect("/Task3/Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserModel inputModel)
        {
            if (!ModelState.IsValid)
            {
               return View(inputModel);
            }

            bool isRegistered = this.task3Service.RegisterUser(inputModel);

            if (!isRegistered)
            {
                ModelState.AddModelError("result", "The username is taken");

                return View(inputModel);
            }

            return LocalRedirect("/Task3/Login");
        }

        [HttpPost]
        public IActionResult Archive(string id)
        {
            this.task3Service.Archive(id);

            return LocalRedirect("/Task3/Login");
        }

        [HttpPost]
        public IActionResult Restore(string id)
        {
            this.task3Service.Restore(id);

            return LocalRedirect("/Task3/Login");
        }
        
        [HttpPost]
        public IActionResult CreateToDoList(CreateToDoListModel inputModel)
        {
            this.task3Service.CreateToDoList(inputModel);

            return LocalRedirect("/Task3/Login");
        }

        [HttpPost]
        public IActionResult EditToDoList(EditToDoListModel inputModel)
        {
            this.task3Service.EditToDoList(inputModel);

            return LocalRedirect("/Task3/Login");
        }
    }
}