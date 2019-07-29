using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VDSoLienLac.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult DefaultError()
        {
            return RedirectToAction("SignIn","Account");
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}