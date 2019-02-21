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
        [Key]
        public int ID { get; set; }
        public float Duration { get; set; }
        public float Price { get; set; }
        public float MaxWeight { get; set; }

        //Foreign keys
        [ForeignKey("Company"), Required]
        public int CompanyRefId { get; set; }
        public Company Company { get; set; }

        [ForeignKey("SourceCity"), Required]
        public int SourceCityRefId { get; set; }
        public City SourceCity { get; set; }

        [ForeignKey("DestinationCity"), Required]
        public int DestinationCityRefId { get; set; }
        public City DestinationCity { get; set; }

        public ICollection<Type> AcceptedTypes { get; set; }

        public bool Equals(Edge other)
        {
            //TODO need better equals methods. CVR
            return this.ID.Equals(other.ID);
        }
    }
}