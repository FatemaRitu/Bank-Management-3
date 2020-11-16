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
    public class TransactionsController : Controller
    {
        private BankContext db = new BankContext();

        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Branch);
            return View(transactions.ToList());
        }
        public ActionResult List()
        {
            var transactions = db.Transactions.Include(t => t.Branch);
            return View(transactions.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountId,Deposit,Withdraw,TransactionDate,BranchId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId= new SelectList(db.Accounts, "AccountId", "BranchName", transaction.BranchId);
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", transaction.BranchId);
            return View(transaction);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", transaction.BranchId);
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountId,Deposit,Withdraw,TransactionDate,BranchId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", transaction.BranchId);
            return View(transaction);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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
