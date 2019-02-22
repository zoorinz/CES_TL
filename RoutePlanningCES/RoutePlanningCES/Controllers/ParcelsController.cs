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
    public class ParcelsController : ApiController
    {
        private TLContext db = new TLContext();

        // GET: api/Parcels
        public IQueryable<Parcel> GetParcels()
        {
            return db.Parcels;
        }

        // GET: api/Parcels/5
        [ResponseType(typeof(Parcel))]
        public IHttpActionResult GetParcel(int id)
        {
            Parcel parcel = db.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            return Ok(parcel);
        }

        // PUT: api/Parcels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParcel(int id, Parcel parcel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parcel.ID)
            {
                return BadRequest();
            }

            db.Entry(parcel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelExists(id))
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

        // POST: api/Parcels
        [ResponseType(typeof(Parcel))]
        public IHttpActionResult PostParcel(Parcel parcel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parcels.Add(parcel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = parcel.ID }, parcel);
        }

        // DELETE: api/Parcels/5
        [ResponseType(typeof(Parcel))]
        public IHttpActionResult DeleteParcel(int id)
        {
            Parcel parcel = db.Parcels.Find(id);
            if (parcel == null)
            {
                return NotFound();
            }

            db.Parcels.Remove(parcel);
            db.SaveChanges();

            return Ok(parcel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParcelExists(int id)
        {
            return db.Parcels.Count(e => e.ID == id) > 0;
        }
    }
}