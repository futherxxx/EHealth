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
    public class FrontPageController : Controller
    {
        private DoctorSearchEntities db = new DoctorSearchEntities();

        // GET: /FrontPage/
        public ActionResult Index()
        {
            return View(db.FrontPages.ToList());
        }

        // GET: /FrontPage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPage frontpage = db.FrontPages.Find(id);
            if (frontpage == null)
            {
                return HttpNotFound();
            }
            return View(frontpage);
        }

      

        // GET: /FrontPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPage frontpage = db.FrontPages.Find(id);
            if (frontpage == null)
            {
                return HttpNotFound();
            }
            return View(frontpage);
        }

        // POST: /FrontPage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,header,textbody,contact")] FrontPage frontpage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frontpage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frontpage);
        }

        // GET: /FrontPage/Delete/5
       

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
