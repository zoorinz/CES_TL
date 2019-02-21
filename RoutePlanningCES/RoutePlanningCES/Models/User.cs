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
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }



        public int ID { get; set; }
       public string Username { get; private set; }
        public string Password { get; private set; }
        public string eMail { get; set; }

        //Foreign key for Parcel
        [ForeignKey("Users"), Required]
        public int UserRefId { get; set; }
        public Parcel Users { get; set; }

    }
}