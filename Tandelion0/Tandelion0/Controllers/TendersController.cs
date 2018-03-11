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
    public class TendersController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Tenders
        public ActionResult Index(Trade viewmodel, int? id)
        {
            //projectmatch = db.projectsDB.Find(ID);
            var TendersDB = db.tendersDB.Include(t => t.Trade);
            //var CreateAccsDB = db.createaccountDB.Include(tm => tm.Trade);

            //List<CreateAccount> AllCompanyName = new List<CreateAccount>();
            //List<CreateAccount> FrequentCompanyname = new List<CreateAccount>();
            
            List<Tender> test = new List<Tender>();
                        
            //test.PICName = CreateAccsDB.ToList().PICName;
            //test.First().CompanyName = CreateAccsDB.First().CompanyName;
            foreach (var item in test)
            {
                //item.PICName = CreateAccsDB.ToList().PICName.First();
                //ViewBag.bit = ProjectName.First();
            }
            
            foreach (var item in TendersDB)
            {
                if (item.TradeID == id || id == null)
                {
                    //item.projectName = ProjectName; **
                    test.Add(item);
                    //ProjectName.FirstOrDefault();
                }
                //ViewBag.bit = ProjectName.First();
            }
           
            if (id == null)
                ViewBag.Title = "Tenderer";
            else
            {
                var tradekDB = db.tradesDB.Where(vm => vm.ID == id).First();
                ViewBag.Title = tradekDB.TradeType.ToString();
            }

            //var tendersDB = db.tendersDB.Include(t => t.Trade);
            //return View(tendersDB.ToList());
            return View(test);
        }

        // GET: Tenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tendersDB.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // GET: Tenders/Create
        public ActionResult Create()
        {
            Tender viewmodel = new Tender();

            //var tendersDB = db.tendersDB.Include(t => t.Trade);
            //return View(tendersDB.ToList());

            //var CreateAccsDB = db.createaccountDB.Include(tm => tm.Trade);

            //List<CreateAccount> AllCompanyName = new List<CreateAccount>();

            //AllCompanyName = CreateAccsDB.Where(tm => tm.TradeID == id).ToList();

            //ViewBag.FrequentCompanyName = db.createaccountDB.Where(td=>td.TradeID == 2).Where(tm => tm.Frequency == 2).ToList();

            //ViewBag.SuggestCompanyName = AllCompanyName.Where(tm => tm.Rating == 3).ToList();
            viewmodel.FrequentCompanyName = db.createaccountDB.Include(tm => tm.Trade).Where(td => td.Frequency == 32).ToList();
            viewmodel.SuggestCompanyName = db.createaccountDB.Include(tm => tm.Trade).ToList();

            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType");
            //ViewBag.BB = new List(db.tradesDB, "ID", "TradeType");
            ViewBag.createaccountID = new SelectList(db.createaccountDB, "ID", "CompanyName");
            return View(viewmodel);
            
        }

        // POST: Tenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,Status,PIC,Designation,HP,ContactNo,TradeID,FrequentCompanyName,CreateAccountID")] Tender tender, Tender viewmodel)
        {
            //Tender supermodel = new Tender();
            if (ModelState.IsValid)
            {
                db.tendersDB.Add(tender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Tender viewmodel = new Tender();
            //viewmodel.FrequentCompanyName = db.createaccountDB.Include(tm => tm.Trade).Where(tm => tm.TradeID == 2).ToList();
            viewmodel.FrequentCompanyName = db.createaccountDB.Include(tm => tm.Trade).Where(td=>td.Rating == 2).ToList();
            viewmodel.SuggestCompanyName = db.createaccountDB.Include(tm => tm.Trade).ToList();
            
            //viewmodel.SuggestCompanyName = db.createaccountDB.Include(tm=)

            //var tendersDB = db.tendersDB.Include(t => t.Trade);
            //return View(tendersDB.ToList());
            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType", tender.TradeID);
            return View(viewmodel);



            /*

            if (ModelState.IsValid)
            {
                db.tendersDB.Add(tender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //var CreateAccsDB = db.createaccountDB.Include(tm => tm.Trade);

            //List<CreateAccount> AllCompanyName = new List<CreateAccount>();

            List<CreateAccount> AllCompanyName = db.createaccountDB.Include(tm=>tm.TradeID).Where(tm => tm.TradeID == 2).ToList();

            ViewBag.FrequentCompanyName = AllCompanyName.Where(tm => tm.Frequency == 2).ToList();

            ViewBag.SuggestCompanyName = AllCompanyName.Where(tm => tm.Rating == 3).ToList();

            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType", tender.TradeID);
            ViewBag.createaccountID = new SelectList(db.createaccountDB, "ID", "CompanyName", tender.CreateAccountID);
            return View(tender);
            */
        }

        // GET: Tenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tendersDB.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType", tender.TradeID);
            return View(tender);
        }

        // POST: Tenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,Status,PIC,Designation,HP,ContactNo,TradeID")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType", tender.TradeID);
            return View(tender);
        }

        // GET: Tenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tendersDB.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // POST: Tenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tender tender = db.tendersDB.Find(id);
            db.tendersDB.Remove(tender);
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
