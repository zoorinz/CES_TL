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
using Models;
using RoutePlanningCES.Models;

namespace RoutePlanningCES.Controllers
{
    public class ExposedConnectionsController : ApiController
    {
        private RoutePlanningCESContext db = new RoutePlanningCESContext();

        // GET: api/ExposedConnections
        public IQueryable<ExposedConnection> GetExposedConnections()
        {
            return db.ExposedConnections;
        }

        // GET: api/ExposedConnections/5
        [ResponseType(typeof(ExposedConnection))]
        public IHttpActionResult GetExposedConnection(int id)
        {
            ExposedConnection exposedConnection = db.ExposedConnections.Find(id);
            if (exposedConnection == null)
            {
                return NotFound();
            }

            return Ok(exposedConnection);
        }

        // PUT: api/ExposedConnections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExposedConnection(int id, ExposedConnection exposedConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exposedConnection.ID)
            {
                return BadRequest();
            }

            db.Entry(exposedConnection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExposedConnectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ExposedConnections
        [ResponseType(typeof(ExposedConnection))]
        public IHttpActionResult PostExposedConnection(ExposedConnection exposedConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExposedConnections.Add(exposedConnection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exposedConnection.ID }, exposedConnection);
        }

        // DELETE: api/ExposedConnections/5
        [ResponseType(typeof(ExposedConnection))]
        public IHttpActionResult DeleteExposedConnection(int id)
        {
            ExposedConnection exposedConnection = db.ExposedConnections.Find(id);
            if (exposedConnection == null)
            {
                return NotFound();
            }

            db.ExposedConnections.Remove(exposedConnection);
            db.SaveChanges();

            return Ok(exposedConnection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExposedConnectionExists(int id)
        {
            return db.ExposedConnections.Count(e => e.ID == id) > 0;
        }
    }
}