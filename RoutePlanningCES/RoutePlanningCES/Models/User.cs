using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class User
    {
        public User(string username, string password) : this()
        {
            this.Username = username;
            this.Password = password;
        }

        private User() { }

        public int ID { get; set; }
        [Required]
        public string Username { get; private set; }
        [Required]
        public string Password { get; private set; }
        public string eMail { get; set; }

    }
}