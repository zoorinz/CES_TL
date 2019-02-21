﻿using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;
using System.Collections.Generic;
using Models;
namespace Models
{
    public class Type
    {
        public Type(string name)
        {
            this.Name = name;
            this.Parcel = new HashSet<Parcel>();
            this.Edges = new HashSet<Edge>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Parcel> Parcel { get; set; }
        public virtual ICollection<Edge> Edges { get; set; }
    }
}