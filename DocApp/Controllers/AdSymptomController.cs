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
    public class AdSymptomController : Controller
    {
        private DoctorSearchEntities db = new DoctorSearchEntities();

        // GET: /AdSymptom/
        public ActionResult Index()
        {
            var item1 = (from e in db.RemedyTables orderby e.Remedy select e).ToList();

           
            int one = 0;

            if (TempData["remedy"] != null)
            {
                one = Convert.ToInt32(TempData["remedy"]);

                var item2 = (from e in db.symptomtables where e.remedy == one orderby e.symptom select e).ToList();

                var item3 = (from e in db.RemedyTables where e.id == one select e.Remedy).FirstOrDefault();

                ViewBag.remname = item3;
                
                ViewBag.alldocs = item1.ToList();

                ViewBag.allsymp = item2.ToArray();

                return View();

            }
            
            ViewBag.alldocs = item1.ToList();
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string one)
        {

            string rem = Request.Form["remedy"];
           
            if (rem != "")
            {
                TempData["remedy"] = rem;

                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

       
       
        // GET: /AdSymptom/Create
        public ActionResult Create()
        {
            var allcat = (from e in db.RemedyTables select e).ToList();

            ViewBag.cat = allcat;
            
            return View();
        }

        // POST: /AdSymptom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,symptom,remedy")] symptomtable symptomtable)
        {
            if (ModelState.IsValid)
            {
                db.symptomtables.Add(symptomtable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(symptomtable);
        }

        // GET: /AdSymptom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            symptomtable symptomtable = db.symptomtables.Find(id);
            if (symptomtable == null)
            {
                return HttpNotFound();
            }

            var allcat = (from e in db.RemedyTables select e).ToList();

            var getremname = (from e in db.RemedyTables where e.id == symptomtable.remedy select e).FirstOrDefault();

            ViewBag.catname = getremname;

            ViewBag.cat = allcat;


            return View(symptomtable);
        }

        // POST: /AdSymptom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,symptom,remedy")] symptomtable symptomtable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symptomtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(symptomtable);
        }

        // GET: /AdSymptom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            symptomtable symptomtable = db.symptomtables.Find(id);
            if (symptomtable == null)
            {
                return HttpNotFound();
            }
            return View(symptomtable);
        }

        // POST: /AdSymptom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            symptomtable symptomtable = db.symptomtables.Find(id);
            db.symptomtables.Remove(symptomtable);
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
