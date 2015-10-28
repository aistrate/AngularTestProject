using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.DataModel;

namespace Registration.Controllers
{
    public class AccountController : Controller
    {
        private RegistrationDbContext db = new RegistrationDbContext();

        public ActionResult Register()
        {
            return View(db.Countries.OrderBy(c => c.Name).ToList());
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
