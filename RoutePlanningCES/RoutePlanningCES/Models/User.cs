using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}