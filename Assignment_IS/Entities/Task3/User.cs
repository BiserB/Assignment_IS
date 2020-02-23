using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Entities.Task3
{
    public class User
    {
        public User(string username, string passHash)
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
            this.PassHash = passHash;
        }

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string PassHash { get; set; }

        public bool IsLoggedIn { get; set; }

        public List<string> MyProperty { get; set; }
    }
}
