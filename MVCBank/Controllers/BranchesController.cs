using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBank.Models;

namespace MVCBank.Controllers
{
    [HandleError]
    public class BranchesController : Controller
    {
        private BankContext db = new BankContext();

        public ActionResult Index()
        {
            return View(db.Branches.ToList());
        }
        public ActionResult List()
        {
            return View(db.Branches.ToList());
        }
      

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BranchName,BranchAddress,BranchPhone")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branch);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BranchName,BranchAddress,BranchPhone")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = db.Branches.Find(id);
            db.Branches.Remove(branch);
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
