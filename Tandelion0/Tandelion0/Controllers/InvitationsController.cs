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
    public class InvitationsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Invitations
        public ActionResult Index()
        {
            var invitationDB = db.invitationDB.Include(i => i.Project).Include(i => i.Tender);
            return View(invitationDB.ToList());
        }

        // GET: Invitations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.invitationDB.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            return View(invitation);
        }

        // GET: Invitations/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName");
            ViewBag.TenderID = new SelectList(db.tendersDB, "ID", "CompanyName");
            return View();
        }

        // POST: Invitations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Message,TenderID,ProjectID")] Invitation invitation)
        {
            if (ModelState.IsValid)
            {
                db.invitationDB.Add(invitation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName", invitation.ProjectID);
            ViewBag.TenderID = new SelectList(db.tendersDB, "ID", "CompanyName", invitation.TenderID);
            return View(invitation);
        }

        // GET: Invitations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.invitationDB.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName", invitation.ProjectID);
            ViewBag.TenderID = new SelectList(db.tendersDB, "ID", "CompanyName", invitation.TenderID);
            return View(invitation);
        }

        // POST: Invitations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Message,TenderID,ProjectID")] Invitation invitation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invitation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName", invitation.ProjectID);
            ViewBag.TenderID = new SelectList(db.tendersDB, "ID", "CompanyName", invitation.TenderID);
            return View(invitation);
        }

        // GET: Invitations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.invitationDB.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            return View(invitation);
        }

        // POST: Invitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invitation invitation = db.invitationDB.Find(id);
            db.invitationDB.Remove(invitation);
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
