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
    public class TradesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Trades
        //why viewmodel must be used?
        public ActionResult Index(Project viewmodel, int? id)
        {
            //projectmatch = db.projectsDB.Find(ID);
            var tradesDB = db.tradesDB.Include(t => t.Project);
            
            //.First(vm=>vm.ProjectID==projectmatch.ID);
            //Console.WriteLine(tradesDB.ID)
            List<Trade> test = new List<Trade>();
            //var projectkDB;
            foreach (var item in tradesDB)
            {
                if (item.ProjectID == id || id == null)
                {
                    //item.projectName = ProjectName; **
                    test.Add(item);
                    
                    //ProjectName.FirstOrDefault();
                    
                }
                
                //ViewBag.bit = ProjectName.First();
                
            }
            //var projectkDB = db.projectsDB.Where(vm => vm.ID == id).First();
            
            
            if(id==null)
                ViewBag.Title = "Trade";
            else
            {
                var projectkDB = db.projectsDB.Where(vm => vm.ID == id).First();
                ViewBag.Title = projectkDB.ProjectName.ToString();
            }
                

            return View(test);
        }


        // GET: Trades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trade trade = db.tradesDB.Find(id);
            if (trade == null)
            {
                return HttpNotFound();
            }
            return View(trade);
        }

        // GET: Trades/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName");
            return View();
        }

        // POST: Trades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TradeType,StartDate,Progress,DueDate,ProjectID,TendererNo")] Trade trade)
        {

            if (ModelState.IsValid)
            {
                db.tradesDB.Add(trade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName", trade.ProjectID);
            return View(trade);
        }

        // GET: Trades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trade trade = db.tradesDB.Find(id);
            if (trade == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName", trade.ProjectID);
            return View(trade);
        }

        // POST: Trades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TradeType,StartDate,Progress,DueDate,ProjectID,TendererNo")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.projectsDB, "ID", "ProjectName", trade.ProjectID);
            return View(trade);
        }

        // GET: Trades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trade trade = db.tradesDB.Find(id);
            if (trade == null)
            {
                return HttpNotFound();
            }
            return View(trade);
        }

        // POST: Trades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trade trade = db.tradesDB.Find(id);
            db.tradesDB.Remove(trade);
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
