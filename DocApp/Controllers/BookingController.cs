using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocApp.Models;
using DocApp.Classes;

namespace DocApp.Controllers
{
    public class BookingController : Controller
    {

        DoctorSearchEntities db = new DoctorSearchEntities();
        // GET: /Booking/
        public ActionResult Booktype()
        {
            return View();
        }


        public ActionResult Bookhme()
        {

            Session["booktype"] = "HME";

            var Hospitals = (from e in db.DocHospitals orderby e.Hospitalname select e).ToList();

            return View(Hospitals);
        }

        public ActionResult Bookcat(int? id)
        {

            var Hospcat = (from e in db.DocRegistratons where e.hostype == id && e.approve == 1 select e).ToList();

            var hosinfo = (from e in db.DocHospitals where e.id == id select e).FirstOrDefault();


            TempData["id"] = id;

            List<DocCategory> Allcat = new List<DocCategory>();
           
            if (Hospcat != null)
            {
                foreach(var item in Hospcat){

                    var Dockat = (from e in db.DocCategories where e.id == item.cattype select e).FirstOrDefault();

                    Allcat.Add(Dockat);
                
                }

                Allcat = (from e in Allcat orderby e.CatName select e).ToList();
               

                ViewBag.info = hosinfo;

                return View(Allcat);

            }

          

            return View();
        }

        public ActionResult Doclist(int? id)
        {

            int hosid = (int)TempData["id"];
            
            var Doclist = (from e in db.DocRegistratons where e.cattype == id && e.hostype == hosid && e.approve == 1 select e).ToList();


            return View(Doclist);
        }
        public ActionResult Bookgme()
        {
            Session["booktype"] = "GME";
            
            var Catlist = (from e in db.DocRegistratons where e.approve == 1 select e.cattype).ToList().Distinct();

            List<DocCategory> Allcat = new List<DocCategory>();

            if (Catlist != null)
            {
                foreach (var item in Catlist)
                {

                    var Dockat = (from e in db.DocCategories where e.id == item  select e).FirstOrDefault();
                    
                    Allcat.Add(Dockat);

                }


                Allcat = (from e in Allcat orderby e.CatName select e).ToList();
                // ViewBag.allcat = Allcat;

                return View(Allcat);

            }

            
            return View();
        }



        public ActionResult Doctorlist(int? id)
        {


            var Doclist = (from e in db.DocRegistratons where e.cattype == id && e.approve == 1 select e).ToList();


            return View("Doclist", Doclist);
        }


        
	}
}