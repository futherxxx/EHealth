using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocApp.Models;

namespace DocApp.Controllers
{
    public class AdminController : Controller
    {
        DoctorSearchEntities db = new DoctorSearchEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Regadmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regadmin(Userdata collect)
        {
            string username = Request.Form["name"].ToLower();
            string pass1 = Request.Form["password"].ToLower();
            string pass2 = Request.Form["password1"].ToLower();

            if (pass1 != pass2)
            {
                ViewBag.error = "ERROR: PASSWORDS ENTERED NOT THE SAME";

                return View();
            }


            var userdata = (from e in db.Userdatas where e.username == username select e).FirstOrDefault();

            if (userdata != null)
            {
                ViewBag.error = "ERROR: USERNAME ALREADY EXISTS";

                return View();

            }

            else
            {
                collect.username = username;
                collect.password = pass1;
                collect.role = "admin";
                collect.surname = "Administrator";


                db.Userdatas.Add(collect);

                db.SaveChanges();

                ViewBag.error = "USER ADDED";

                return View();

            }


            return View();
        }
	}
} 