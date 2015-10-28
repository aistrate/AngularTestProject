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
using Registration.DataModel;
using Registration.Entities;

namespace Registration.Controllers
{
    public class CountriesController : ApiController
    {
        private RegistrationDbContext db = new RegistrationDbContext();

        // GET: api/Countries
        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [Route("api/Countries/{id}/Provinces")]
        public IHttpActionResult GetProvinces(int id)
        {
            Country country = db.Countries.AsNoTracking().Include(c => c.Provinces)
                                          .FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country.Provinces);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
