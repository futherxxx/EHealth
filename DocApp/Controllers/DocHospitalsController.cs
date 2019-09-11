using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocApp.Models;
using System.Web.Script.Serialization;

namespace DocApp.Controllers
{
    public class DocHospitalsController : Controller
    {
        private DoctorSearchEntities db = new DoctorSearchEntities();

        // GET: /DocHospitals/
        public ActionResult Index()
        {
            return View(db.DocHospitals.ToList());
        }

        // GET: /DocHospitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocHospital dochospital = db.DocHospitals.Find(id);
            if (dochospital == null)
            {
                return HttpNotFound();
            }
            return View(dochospital);
        }

        // GET: /DocHospitals/Create
        public ActionResult Create()
        {
            string file = Server.MapPath("~/Images/states.json");
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist = ser.Deserialize<List<string>>(Json);


            ViewBag.states = personlist;
            
            
            return View();
        }

        // POST: /DocHospitals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Hospitalname,Hospitaladdress,State,Otherinfo,date,mobile")] DocHospital dochospital)
        {
            if (ModelState.IsValid)
            {
                dochospital.date = DateTime.Now;
                
                db.DocHospitals.Add(dochospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dochospital);
        }

        // GET: /DocHospitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocHospital dochospital = db.DocHospitals.Find(id);
            if (dochospital == null)
            {
                return HttpNotFound();
            }

            string file = Server.MapPath("~/Images/states.json");
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist = ser.Deserialize<List<string>>(Json);


            ViewBag.states = personlist;



            return View(dochospital);
        }

        // POST: /DocHospitals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Hospitalname,Hospitaladdress,State,Otherinfo,date,mobile")] DocHospital dochospital)
        {
            if (ModelState.IsValid)
            {
                dochospital.date = DateTime.Now;
                
                db.Entry(dochospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dochospital);
        }

        // GET: /DocHospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocHospital dochospital = db.DocHospitals.Find(id);
            if (dochospital == null)
            {
                return HttpNotFound();
            }
            return View(dochospital);
        }

        // POST: /DocHospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocHospital dochospital = db.DocHospitals.Find(id);
            db.DocHospitals.Remove(dochospital);
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
