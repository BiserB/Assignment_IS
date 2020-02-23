using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Entities.Task3
{
    public class ToDoList
    {
        public ToDoList(Guid userId, string content)
        {
            this.Id = Guid.NewGuid();
            this.UserId = userId;
            this.Content = content;
        }
        
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public string Content { get; private set; }

        public bool IsArchived { get; private set; }
        
        public void Archive()
        {
            this.IsArchived = true;
        }

        public void Restore()
        {
            this.IsArchived = false;
        }
        
        public void EditContent(string content)
        {
            if (String.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Invalid to-do content");
            }

            this.Content = content;
        }
    }
}
