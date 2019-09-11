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
    public class AdusersController : Controller
    {
        private DoctorSearchEntities db = new DoctorSearchEntities();

        // GET: /Adusers/
        public ActionResult Index()
        {
            var users = (from e in db.Userdatas where e.role != "admin" select e).ToList();

            return View(users);
        }

        // GET: /Adusers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdata userdata = db.Userdatas.Find(id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // GET: /Adusers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Adusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,surname,firstname,email,phone,username,password,regdate,gender,dob,maritalstatus,address,medicalhistry,otherinfo,age,role")] Userdata userdata)
        {
            if (ModelState.IsValid)
            {
                db.Userdatas.Add(userdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdata);
        }

        // GET: /Adusers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdata userdata = db.Userdatas.Find(id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // POST: /Adusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,surname,firstname,email,phone,username,password,regdate,gender,dob,maritalstatus,address,medicalhistry,otherinfo,age,role")] Userdata userdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdata);
        }

        // GET: /Adusers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdata userdata = db.Userdatas.Find(id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // POST: /Adusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userdata userdata = db.Userdatas.Find(id);
            db.Userdatas.Remove(userdata);
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
