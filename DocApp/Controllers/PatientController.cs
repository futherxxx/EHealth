using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DocApp.Models;
using System.Data.Entity;
using DocApp.Classes;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DocApp.Controllers
{
    public class PatientController : Controller
    {
        //
        DoctorSearchEntities db = new DoctorSearchEntities();

        public ActionResult Index()
        {
            

            string user = Session["name"].ToString();

            string pass = Session["password"].ToString();


            var duser = (from e in db.Userdatas where e.username == user.ToLower() && e.password == pass.ToLower() select e).FirstOrDefault();

            return View(duser);  

        }


        [HttpPost]
        public ActionResult Index(Userdata collect)
        {

            string gender = Request.Form["gender"];
            string marriedstatus = Request.Form["maritalstatus"];
            string medhistory = Request.Form["medicalhistry"];
            string age = Request.Form["age"];
            DateTime nowdate = DateTime.Now;

            collect.gender = gender;
            collect.maritalstatus = marriedstatus;
            collect.medicalhistry = medhistory;
            collect.regdate = nowdate;
            collect.age = Convert.ToInt32(age);

          

            if (ModelState.IsValid)
            {

                db.Entry(collect).State = EntityState.Modified;

                db.SaveChanges();

                Allstatic.Userregistration = "Profile Successful Updated";

                Allstatic.UserDetails = collect;

            }

            if (Allstatic.Bookdoc == "bookdoc")
            {

                Allstatic.Bookdoc = null;

                return RedirectToAction("Bookdoctor");

            }

            return RedirectToAction("UserPage", "Home");
        }


        public ActionResult Bookdoctor(int? docid, string bookboc)
        {
           
            string user = Session["name"].ToString();

            string pass = Session["password"].ToString();


            if (Allstatic.Docdetail == null)
            {

                var getdoc = (from e in db.DocRegistratons where e.id == docid && e.approve == 1 select e).FirstOrDefault();

                Allstatic.Docdetail = getdoc;

                Allstatic.Bookdoc = bookboc;

            }


            
            var duser = (from e in db.Userdatas where e.username == user.ToLower() && e.password == pass.ToLower() select e).FirstOrDefault();



            if (duser.surname == null)
            {

                return  RedirectToAction("Index");

            }

            string name = duser.firstname + " " + duser.surname;

            ViewBag.name = name;

            ViewBag.ailment = Allstatic.Ailment;

            return View();  
        }


        [HttpPost]
        public ActionResult Bookdoctor(UserAppoint collect)
        {

            
            string name = Request.Form["name"];
            string date = Request.Form["date"];
            string timeofvisit = Request.Form["timeofvisit"];
            string otherinfo = Request.Form["othinfo"];
            DateTime nowdate = DateTime.Now;

            var result = Convert.ToDateTime(timeofvisit);
            timeofvisit = result.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);

            string booktype = ""; ///////////////////////booking type

            if (Session["booktype"] != null)
            {
                booktype = Session["booktype"].ToString();

            }
            collect.userid = Allstatic.UserDetails.id;
            collect.username = name;
            collect.docname = Allstatic.Docdetail.docname;
            collect.dochos = Allstatic.Docdetail.hospital;
            collect.docaddress = Allstatic.Docdetail.hospital;
            collect.ailment = otherinfo;
            collect.dateofappoint = Convert.ToDateTime(date);
            collect.timeofvisit = timeofvisit;
            collect.date = nowdate;
            collect.docid = Allstatic.Docdetail.id;
            collect.booktype = booktype;
            collect.approve = 0;
            collect.treatapprove = 0;



            db.UserAppoints.Add(collect);

            db.SaveChanges();

            Allstatic.Usersuccessbook = "Appintment Booking Successful";

            return RedirectToAction("Userpage", "Home");


        }


        public ActionResult Allbooking()
        {

            var Allbook = (from e in db.UserAppoints where e.userid == Allstatic.UserDetails.id orderby e.id  descending select e).ToList();

            return View(Allbook);
        
        }

        public ActionResult Medhistory()
        {

            var medrecord1 = (from s in db.UserMedHistories
                              where s.userid == Allstatic.UserDetails.id
                              join st in db.DocRegistratons
                              on s.docid equals st.id
                              select new Medhistory
                              {
                                  ailment = s.ailment,
                                  treatment = s.treatment_prescribe,
                                  testresult = s.testresult,
                                  test = s.test_done,
                                  recommendation = s.recommendation,
                                  date = s.date,
                                  docname = st.docname,
                                  hospital = st.hospital
                              }).ToList();


            ViewBag.medrecord = medrecord1;
            
            
            
            return View();

        }
      
    }
}
