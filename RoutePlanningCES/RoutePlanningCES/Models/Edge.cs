﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Models
{
    public class Edge : IEquatable<Edge>
    {
        public Edge(float duration, float price, float maxWeight, Company company, City source, City destination, ICollection<Type> acceptedTypes) : 
            this(duration, price, maxWeight, source, destination)
        {
            this.Type = acceptedTypes;
            this.Company = company;
        }

        public Edge(float duration, float price, float maxWeight, City source, City destination) 
            : this()
        {
            this.Duration = duration;
            this.Price = price;
            this.MaxWeight = maxWeight;
            this.SourceCity = source;
            this.DestinationCity = destination;
        }

        public Edge()
        {
            this.Type = new HashSet<Type>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float MaxWeight { get; set; }

        //Foreign keys
        [Required]
        public Company Company { get; set; }
        [Required]
        public City SourceCity { get; set; }
        [Required]
        public City DestinationCity { get; set; }
        public ICollection<Type> Type { get; set; }

        public bool Equals(Edge other)
        {
            //TODO need better equals methods. CVR
            return this.ID.Equals(other.ID);
        }
    }
}