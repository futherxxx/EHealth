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
    public class DoctorcategoryController : Controller
    {
        private DoctorSearchEntities db = new DoctorSearchEntities();

        // GET: /Doctorcategory/
        public ActionResult Index()
        {
            return View(db.DocCategories.ToList());
        }

        // GET: /Doctorcategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocCategory doccategory = db.DocCategories.Find(id);
            if (doccategory == null)
            {
                return HttpNotFound();
            }
            return View(doccategory);
        }

        // GET: /Doctorcategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Doctorcategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,CatName,date")] DocCategory doccategory)
        {
            if (ModelState.IsValid)
            {
                doccategory.date = DateTime.Now;
                
                db.DocCategories.Add(doccategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doccategory);
        }

        // GET: /Doctorcategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocCategory doccategory = db.DocCategories.Find(id);
            if (doccategory == null)
            {
                return HttpNotFound();
            }
            return View(doccategory);
        }

        // POST: /Doctorcategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,CatName,date")] DocCategory doccategory)
        {
            if (ModelState.IsValid)
            {
                                
                db.Entry(doccategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doccategory);
        }

        // GET: /Doctorcategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocCategory doccategory = db.DocCategories.Find(id);
            if (doccategory == null)
            {
                return HttpNotFound();
            }
            return View(doccategory);
        }

        // POST: /Doctorcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocCategory doccategory = db.DocCategories.Find(id);
            db.DocCategories.Remove(doccategory);
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
