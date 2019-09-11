using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocApp.Models;

namespace DocApp.Controllers
{
    public class DoctorsController : Controller
    {
        private DoctorSearchEntities db = new DoctorSearchEntities();

        // GET: /Doctors/
        public ActionResult Index()
        {
            var item1 = db.DocRegistratons.ToList();

           // var catname = from e in db.DocCategories where e.id = item1.

            List<string> catname = new List<string>();

            foreach(var item in item1){

                var catnames = (from e in db.DocCategories where e.id == item.cattype select e.CatName).FirstOrDefault();

                catname.Add(catnames);

            }


            ViewBag.catname = catname.ToArray();

            ViewBag.alldocs = item1.ToArray();
            
            return View();
        }

        // GET: /Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocRegistraton docregistraton = db.DocRegistratons.Find(id);
            if (docregistraton == null)
            {
                return HttpNotFound();
            }
            return View(docregistraton);
        }

       
        

        // GET: /Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocRegistraton docregistraton = db.DocRegistratons.Find(id);
            if (docregistraton == null)
            {
                return HttpNotFound();
            }

            var hosnames = (from e in db.DocHospitals select e).ToList();

            ViewBag.hosnames = hosnames;

            return View(docregistraton);
        }

        // POST: /Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,hospital")] DocRegistraton docregistraton)
        {
            if (ModelState.IsValid)
            {
                int hosid = Convert.ToInt32(docregistraton.hospital);

                var gethos = (from e in db.DocHospitals where e.id == hosid select e).FirstOrDefault();

                var getdoc = (from e in db.DocRegistratons where e.id == docregistraton.id select e).FirstOrDefault();

                getdoc.hospital = gethos.Hospitalname;

                getdoc.address = gethos.Hospitaladdress;

                getdoc.state = gethos.State;

                getdoc.hostype = gethos.id;

                getdoc.approve = 1;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docregistraton);
        }

        // GET: /Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocRegistraton docregistraton = db.DocRegistratons.Find(id);
            if (docregistraton == null)
            {
                return HttpNotFound();
            }
            return View(docregistraton);
        }

        // POST: /Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocRegistraton docregistraton = db.DocRegistratons.Find(id);
            db.DocRegistratons.Remove(docregistraton);
            db.SaveChanges();
            return RedirectToAction("Index");
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
