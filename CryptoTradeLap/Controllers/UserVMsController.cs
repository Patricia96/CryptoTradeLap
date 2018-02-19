using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CryptoTradeLap.Models;

namespace CryptoTradeLap.Controllers
{
    public class UserVMsController : Controller
    {
        private CryptoTraderEntities db = new CryptoTraderEntities();

        // GET: UserVMs
        public ActionResult Index()
        {
            return View(db.UserVMs.ToList());
        }

        // GET: UserVMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVM userVM = db.UserVMs.Find(id);
            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }

        // GET: UserVMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserVMs/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,created,email,password,firstname,lastname,salt,Role")] UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                db.UserVMs.Add(userVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userVM);
        }

        // GET: UserVMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVM userVM = db.UserVMs.Find(id);
            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }

        // POST: UserVMs/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,created,email,password,firstname,lastname,salt,Role")] UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userVM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userVM);
        }

        // GET: UserVMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVM userVM = db.UserVMs.Find(id);
            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }

        // POST: UserVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserVM userVM = db.UserVMs.Find(id);
            db.UserVMs.Remove(userVM);
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
