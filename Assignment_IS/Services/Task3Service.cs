using Assignment_IS.Data;
using Assignment_IS.Entities.Task3;
using Assignment_IS.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_IS.Services
{
    public class Task3Service
    {
        public static string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            return Task3Repo.GetUsers();
        }

        public IReadOnlyCollection<ToDoList> GetTodoLists(User currentUser)
        {
            return Task3Repo.GetToDosForUser(currentUser.Id);
        }

        public IReadOnlyCollection<ToDoList> GetArchivedTodoLists(User currentUser)
        {
            return Task3Repo.GetArchivedToDosForUser(currentUser.Id);
        }

        public bool RegisterUser(RegisterUserModel model)
        {
            if (Task3Repo.GetUsers().Any(u => u.Username == model.Username))
            {
                return false;
            }

            string passHash = ComputeSha256Hash(model.Password);

            User newUser = new User(model.Username, passHash);

            Task3Repo.AddUser(newUser);

            return true;
        }
        
        public User SignIn(string username, string password)
        {
            string passHash = ComputeSha256Hash(password);

            List<User> users = Task3Repo.GetUsers().ToList();

            User user = users.FirstOrDefault(u => u.Username == username && u.PassHash == passHash);

            if (user == null)
            {
                return null;
            }

            users.ForEach(u => u.IsLoggedIn = false);

            user.IsLoggedIn = true;
            
            return user;
        }

        public User GetCurrentUser()
        {
            return Task3Repo.GetUsers().FirstOrDefault(u => u.IsLoggedIn);
        }

        public bool IsLoggedIn(string id)
        {
            User user = Task3Repo.GetUser(id);

            if (user == null)
            {
                return false;
            }

            return user.IsLoggedIn;
        }

        public bool Logout(string id)
        {
            User user = Task3Repo.GetUser(id);

            if (user == null)
            {
                return false;
            }

            user.IsLoggedIn = false;

            return true;
        }

        public void Archive(string id)
        {
            ToDoList selected = Task3Repo.GetToDo(id);

            if (selected != null)
            {
                selected.Archive();
            }
        }

        public void Restore(string id)
        {
            ToDoList selected = Task3Repo.GetToDo(id);

            if (selected != null)
            {
                selected.Restore();
            }
        }

        public void CreateToDoList(CreateToDoListModel model)
        {
            Guid creatorId;

            if (!Guid.TryParse(model.UserId, out creatorId))
            {
                throw new ArgumentException("Invalid creator id");
            }

            User currentUser = this.GetCurrentUser();

            if (currentUser.Id != creatorId)
            {
                throw new ArgumentException("Invalid creator id");
            }

            ToDoList toDo = new ToDoList(creatorId, model.Content);

            Task3Repo.AddToDo(toDo);
        }

        public void EditToDoList(EditToDoListModel model)
        {
            Guid todoId;

            if (!Guid.TryParse(model.Id, out todoId))
            {
                throw new ArgumentException("Invalid to-do id");
            }

            Guid creatorId;

            if (!Guid.TryParse(model.UserId, out creatorId))
            {
                throw new ArgumentException("Invalid creator id");
            }

            User currentUser = this.GetCurrentUser();

            if (currentUser.Id != creatorId)
            {
                throw new ArgumentException("Invalid creator id");
            }

            ToDoList selectedToDo = Task3Repo.GetToDo(model.Id);

            if (selectedToDo == null)
            {
                throw new ArgumentException("No such to-do");
            }

            selectedToDo.EditContent(model.Content);
        }
    }
}
