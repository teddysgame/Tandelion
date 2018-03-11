using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tandelion0.DAL;
using Tandelion0.Models;

namespace Tandelion0.Controllers
{
    public class CreateAccountsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: CreateAccounts
        public ActionResult Index()
        {
            return View(db.createaccountDB.ToList());
        }

        // GET: CreateAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateAccount createAccount = db.createaccountDB.Find(id);
            if (createAccount == null)
            {
                return HttpNotFound();
            }
            return View(createAccount);
        }

        // GET: CreateAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,PICName,Address,Designation,PICContactNo,CompanyContactNo,FaxNo,Email,RegistrationNo,Rating,TradeID,Frequency")] CreateAccount createAccount)
        {
            if (ModelState.IsValid)
            {
                db.createaccountDB.Add(createAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createAccount);
        }

        // GET: CreateAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateAccount createAccount = db.createaccountDB.Find(id);
            if (createAccount == null)
            {
                return HttpNotFound();
            }
            return View(createAccount);
        }

        // POST: CreateAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,PICName,Address,Designation,PICContactNo,CompanyContactNo,FaxNo,Email,RegistrationNo,Rating,TradeID,Frequency")] CreateAccount createAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createAccount);
        }

        // GET: CreateAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateAccount createAccount = db.createaccountDB.Find(id);
            if (createAccount == null)
            {
                return HttpNotFound();
            }
            return View(createAccount);
        }

        // POST: CreateAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateAccount createAccount = db.createaccountDB.Find(id);
            db.createaccountDB.Remove(createAccount);
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
