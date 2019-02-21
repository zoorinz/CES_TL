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



        public int ID { get; set; }
       public string Username { get; private set; }
        public string Password { get; private set; }
        public string eMail { get; set; }

        //Foreign key for Parcel
        public int ParcelId { get; set; }
        public Parcel Parcel { get; set;}
    }
}