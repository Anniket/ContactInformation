using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ContactController : ApiController
    {
        private MvcApplication1.Models.DbModel db = new MvcApplication1.Models.DbModel();

        // GET api/Contact
        public IEnumerable<tblContactInfo> GettblContactInfoes()
        {
            return db.tblContactInfoes.AsEnumerable();
        }

        // GET api/Contact/5
        public tblContactInfo GettblContactInfo(int id)
        {
            tblContactInfo tblcontactinfo = db.tblContactInfoes.Find(id);
            if (tblcontactinfo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tblcontactinfo;
        }

        // PUT api/Contact/5
        public HttpResponseMessage PuttblContactInfo(int id, tblContactInfo tblcontactinfo)
        {
            if (ModelState.IsValid && id == tblcontactinfo.Id)
            {
                db.Entry(tblcontactinfo).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Contact
        public HttpResponseMessage PosttblContactInfo(tblContactInfo tblcontactinfo)
        {
            if (ModelState.IsValid)
            {
                db.tblContactInfoes.Add(tblcontactinfo);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tblcontactinfo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tblcontactinfo.Id }));
                return response;
                    //CreatedAtRoute("DefaultApi", new { id = tblcontactinfo.Id }, tblcontactinfo);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Contact/5
        public HttpResponseMessage DeletetblContactInfo(int id)
        {
            tblContactInfo tblcontactinfo = db.tblContactInfoes.Find(id);
            if (tblcontactinfo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tblContactInfoes.Remove(tblcontactinfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tblcontactinfo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}