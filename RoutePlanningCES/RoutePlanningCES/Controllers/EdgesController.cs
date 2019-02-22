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

        // GET: api/Edges/5
        [ResponseType(typeof(Edge))]
        public IHttpActionResult GetEdge(int id)
        {
            Edge edge = db.Edge.Find(id);
            if (edge == null)
            {
                return NotFound();
            }

            return Ok(edge);
        }

        // PUT: api/Edges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEdge(int id, Edge edge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != edge.ID)
            {
                return BadRequest();
            }

            db.Entry(edge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EdgeExists(id))
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

        // POST: api/Edges
        [ResponseType(typeof(Edge))]
        public IHttpActionResult PostEdge(Edge edge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Edge.Add(edge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = edge.ID }, edge);
        }

        // DELETE: api/Edges/5
        [ResponseType(typeof(Edge))]
        public IHttpActionResult DeleteEdge(int id)
        {
            Edge edge = db.Edge.Find(id);
            if (edge == null)
            {
                return NotFound();
            }

            db.Edge.Remove(edge);
            db.SaveChanges();

            return Ok(edge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EdgeExists(int id)
        {
            return db.Edge.Count(e => e.ID == id) > 0;
        }
    }
}