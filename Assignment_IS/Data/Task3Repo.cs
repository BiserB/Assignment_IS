using Assignment_IS.Entities.Task3;
using Assignment_IS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Data
{
    public static class Task3Repo
    {
        private static List<User> Users = new List<User>();
        private static List<ToDoList> ToDos = new List<ToDoList>();

        public static IReadOnlyCollection<User> GetUsers()
        {
            return Users.AsReadOnly();
        }

        public static User GetUser(string id)
        {
            return Users.FirstOrDefault(u => u.Id.ToString() == id);
        }

        public static void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Invalid User");
            }

            Users.Add(user);
        }

        public static IReadOnlyCollection<ToDoList> GetToDosForUser(Guid id)
        {
            return ToDos.Where(t => t.UserId.Equals(id) && !t.IsArchived).ToList().AsReadOnly();
        }

        public static IReadOnlyCollection<ToDoList> GetArchivedToDosForUser(Guid id)
        {
            return ToDos.Where(t => t.UserId.Equals(id) && t.IsArchived).ToList().AsReadOnly();
        }

        public static ToDoList GetToDo(Guid id)
        {
            return ToDos.FirstOrDefault(t => t.Id == id);
        }

        public static void AddToDo(ToDoList todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException("Invalid to-do list");
            }

            ToDos.Add(todo);
        }

        public static void SeedData()
        {
            List<User> demoUsers = new List<User>()
            {
                new User("admin", Task3Service.ComputeSha256Hash("1234")),
                new User("demo1", Task3Service.ComputeSha256Hash("pass")),
                new User("demo2", Task3Service.ComputeSha256Hash("pass")),
            };

            Users.AddRange(demoUsers);

            List<ToDoList> toDos = new List<ToDoList>()
            {
                new ToDoList(Users.First().Id, "My first sample to-do"),
                new ToDoList(Users.First().Id, "Second to-do: To finish the application!"),
                new ToDoList(Users.First().Id, "Number 3: a way to improve productivity.")
            };

            ToDos.AddRange(toDos);
        }
    }

    
}
