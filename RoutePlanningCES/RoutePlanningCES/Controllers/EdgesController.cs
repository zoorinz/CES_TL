using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RoutePlanningCES.Controllers
{
    public class EdgesController : ApiController
    {
        private TLContext db = new TLContext();

        // GET: api/Edges
        public IQueryable<Edge> GetEdges()
        {
            return db.GetAllEdgesQuery(db);
        }
        
    }
}