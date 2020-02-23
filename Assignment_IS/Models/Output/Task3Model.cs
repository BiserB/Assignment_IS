using Assignment_IS.Entities.Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Models.Output
{
    public class Task3Model
    {
        public User CurrentUser { get; set; }

        public IReadOnlyCollection<User> Users { get; set; } = new List<User>();

        public IReadOnlyCollection<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();

        public IReadOnlyCollection<ToDoList> Archived { get; set; } = new List<ToDoList>();
    }
}
