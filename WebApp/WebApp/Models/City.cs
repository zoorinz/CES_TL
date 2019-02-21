﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class City
    {
        public City(CityNames name)
        {
            this.Name = name;
        }
        public CityNames Name { get; private set; }
        public uint CityId { get { return (uint)Name; } }
    }

}