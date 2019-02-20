using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace MvcOwin.Models
{
    public class UserManager
    {
        private List<User> _users = new List<User>();

        public UserManager()
        {
            _users.AddRange(new[]
            {
                new User()
                {
                    Id = 1,
                    Username = "user1",
                    Password = "user1",
                    Registered = DateTimeOffset.UtcNow,
                    Roles = { new Role()
                    {
                        Id = 1,
                        Name = "User"
                    },
                        new Role()
                        {
                            Id = 2,
                            Name = "Employee"
                        }
                    }
                },
                new User()
                {
                    Id = 2,
                    Username = "admin",
                    Password = "admin",
                    Registered = DateTimeOffset.UtcNow,
                    Roles = { new Role()
                        {
                            Id = 3,
                            Name = "Admin"
                        }
                    }
                },
            });
        }

        public User GetUser(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}