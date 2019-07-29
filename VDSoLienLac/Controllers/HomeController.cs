using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using VDSoLienLac.Models;
using VDSoLienLac.Principal;

namespace VDSoLienLac.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult UserProfile()
        {
            if (User != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("SignIn", "Account");
            }
        }

        public ActionResult ManagerPartial()
        {
            return PartialView();
        }

        public ActionResult NavigationPartial()
        {
            return PartialView();
        }

        public ActionResult ModalPartial()
        {
            return PartialView();
        }

        public ActionResult PageTableTime()
        {
            return View();
        }

        public ActionResult PageListScore()
        {
            return View();
        }

        public ActionResult PageClassList()
        {
            return View();
        }

        public ActionResult PageTeacherInfo()
        {
            return View();
        }

        public ActionResult PageTruant()
        {
            return View();
        }

        public ActionResult PageStudentManager()
        {
            return View();
        }

        public ActionResult TestSignal()
        {
            return View();
        }

        public ActionResult ReceiveNotification()
        {
            return View();
        }
    }
}
