using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoutePlanningCES.Models.DTOs;

namespace RoutePlanningCES.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            var model = new HomeDTO
            {
                SourceCitites = new List<CityDTO>
                {
                    new CityDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "Copenhagen"
                    },
                    new CityDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "Snekkersten"
                    },
                    new CityDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bucharest"
                    }
                },

                DestinationCitites = new List<CityDTO>
                {
                    new CityDTO
                    {
                    Id = Guid.NewGuid(),
                    Name = "Copenhagen"
                },
                new CityDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "Snekkersten"
                },
                new CityDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "Bucharest"
                }
                },

                ParcelTypes = new List<ParcelTypeDTO>
                {
                    new ParcelTypeDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "Weapons"
                    },
                    new ParcelTypeDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pigs"
                    }
                }
            };
            return View(model);
        }



    }
}