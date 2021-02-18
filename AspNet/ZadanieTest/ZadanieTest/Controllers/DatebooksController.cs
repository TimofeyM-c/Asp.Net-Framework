using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZadanieTest.Models;

namespace ZadanieTest.Controllers
{
    public class DatebooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Datebooks
        public ActionResult Index()
        {
            var datebooks = db.datebooks.Include(d => d.Tip);
            
            
            return View(datebooks.ToList());
        }

        // GET: Datebooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datebook datebook = db.datebooks.Find(id);
            if (datebook == null)
            {
                return HttpNotFound();
            }
            return View(datebook);
        }

        // GET: Datebooks/Create
        public ActionResult Create()
        {
            ViewBag.TipId = new SelectList(db.tips, "Id", "Name");
            
            
            return View();
        }

        // POST: Datebooks/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,Name,Tema,TimeBegin,TimeEnd,Adres,Description,TipId")] Datebook datebook )
        {
            
            
            if (ModelState.IsValid)
            {
                db.datebooks.Add(datebook);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            
           
                               
            return View(datebook);
        }

        // GET: Datebooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datebook datebook = db.datebooks.Find(id);
            if (datebook == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipId = new SelectList(db.tips, "Id", "Name", datebook.TipId);
            return View(datebook);
        }

        // POST: Datebooks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include = "Id,Name,Tema,TimeBegin,TimeEnd,Adres,Description,TipId")] Datebook datebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipId = new SelectList(db.tips, "Id", "Name", datebook.TipId);
            
            return View(datebook);
        }

        // GET: Datebooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datebook datebook = db.datebooks.Find(id);
            if (datebook == null)
            {
                return HttpNotFound();
            }
            return View(datebook);
        }

        // POST: Datebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datebook datebook = db.datebooks.Find(id);
            db.datebooks.Remove(datebook);
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
