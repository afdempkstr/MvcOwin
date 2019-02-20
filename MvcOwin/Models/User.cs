using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOwin.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTimeOffset Registered { get; set; }

        public List<Role> Roles { get; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}