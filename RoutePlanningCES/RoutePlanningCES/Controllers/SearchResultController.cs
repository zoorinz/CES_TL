using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoutePlanningCES.Models.DTOs;

namespace RoutePlanningCES.Controllers
{
    public class SearchResultController : Controller
    {
        public ActionResult SearchResult(int SourceId, int DestinationId, List<int> ParcelTypes, int weight, int width, int height, int length)
        {
            var result = new SearchResultDTO();
            return View(result);
        }
    }
}