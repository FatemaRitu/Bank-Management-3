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
    public class AccountsController : Controller
    {
        private BankContext db = new BankContext();
        
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Branch).Include(a => a.Customer);
            return View(accounts.ToList());
        }
        public ActionResult List()
        {
            var accounts = db.Accounts.Include(a => a.Branch).Include(a => a.Customer);
            return View(accounts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }


        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,CustomerId,BranchId,AccountType,OpeningBalance,CreateDate")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", account.BranchId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName", account.CustomerId);
            return View(account);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", account.BranchId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName", account.CustomerId);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,CustomerId,BranchId,AccountType,OpeningBalance,CreateDate")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", account.BranchId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "CustomerName", account.CustomerId);
            return View(account);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
