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
    public class AdremedyController : Controller
    {
        private DoctorSearchEntities db = new DoctorSearchEntities();

        // GET: /Adremedy/
        public ActionResult Index()
        {

            var item1 = db.RemedyTables.ToList();
            
            List<string> catname = new List<string>();

            foreach (var item in item1)
            {

                var catnames = (from e in db.DocCategories where e.id == item.cattype select e.CatName).FirstOrDefault();

                catname.Add(catnames);

            }

            ViewBag.catname = catname.ToArray();

            ViewBag.alldocs = item1.ToArray();
            
            
            return View();


        }

        // GET: /Adremedy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemedyTable remedytable = db.RemedyTables.Find(id);
            if (remedytable == null)
            {
                return HttpNotFound();
            }
            return View(remedytable);
        }

        // GET: /Adremedy/Create
        public ActionResult Create()
        {
            var allcat = (from e in db.DocCategories select e).ToList();

            ViewBag.cat = allcat;
            
            return View();
        }

        // POST: /Adremedy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Remedy,Definition,date,cattype,Causes,Prevention")] RemedyTable remedytable)
        {
            if (ModelState.IsValid)
            {
                remedytable.date = DateTime.Now;           
                db.RemedyTables.Add(remedytable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(remedytable);
        }

        // GET: /Adremedy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemedyTable remedytable = db.RemedyTables.Find(id);
            if (remedytable == null)
            {
                return HttpNotFound();
            }

            var allcat = (from e in db.DocCategories select e).ToList();

            var getcatname = (from e in db.DocCategories where e.id == remedytable.cattype select e).FirstOrDefault();

            ViewBag.catname = getcatname;
            
            ViewBag.cat = allcat;
            return View(remedytable);
        }

        // POST: /Adremedy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Remedy,Definition,date,cattype,Causes,Prevention")] RemedyTable remedytable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remedytable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(remedytable);
        }

        // GET: /Adremedy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemedyTable remedytable = db.RemedyTables.Find(id);
            if (remedytable == null)
            {
                return HttpNotFound();
            }
            return View(remedytable);
        }

        // POST: /Adremedy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RemedyTable remedytable = db.RemedyTables.Find(id);
            db.RemedyTables.Remove(remedytable);
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
