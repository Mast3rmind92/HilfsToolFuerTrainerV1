using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HilfsToolFuerTrainerV1.Models;

namespace HilfsToolFuerTrainerV1.Controllers
{
    public class SpielerController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: Spieler
        public ActionResult Index()
        {
            var t_Spieler = db.T_Spieler.Include(t => t.T_Absenzen1).Include(t => t.T_Bussen1);
            return View(t_Spieler.ToList());
        }

        // GET: Spieler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Spieler t_Spieler = db.T_Spieler.Find(id);
            if (t_Spieler == null)
            {
                return HttpNotFound();
            }
            return View(t_Spieler);
        }

        // GET: Spieler/Create
        public ActionResult Create()
        {
            ViewBag.FK_Absenzen = new SelectList(db.T_Absenzen, "ID", "Bezeichnung");
            ViewBag.FK_Bussen = new SelectList(db.T_Bussen, "ID", "Grund");
            return View();
        }

        // POST: Spieler/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vorname,Nachname,TelefonNr,FK_Absenzen,FK_Bussen")] T_Spieler t_Spieler)
        {
            if (ModelState.IsValid)
            {
                db.T_Spieler.Add(t_Spieler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Absenzen = new SelectList(db.T_Absenzen, "ID", "Bezeichnung", t_Spieler.FK_Absenzen);
            ViewBag.FK_Bussen = new SelectList(db.T_Bussen, "ID", "Grund", t_Spieler.FK_Bussen);
            return View(t_Spieler);
        }

        // GET: Spieler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Spieler t_Spieler = db.T_Spieler.Find(id);
            if (t_Spieler == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Absenzen = new SelectList(db.T_Absenzen, "ID", "Bezeichnung", t_Spieler.FK_Absenzen);
            ViewBag.FK_Bussen = new SelectList(db.T_Bussen, "ID", "Grund", t_Spieler.FK_Bussen);
            return View(t_Spieler);
        }

        // POST: Spieler/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vorname,Nachname,TelefonNr,FK_Absenzen,FK_Bussen")] T_Spieler t_Spieler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Spieler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Absenzen = new SelectList(db.T_Absenzen, "ID", "Bezeichnung", t_Spieler.FK_Absenzen);
            ViewBag.FK_Bussen = new SelectList(db.T_Bussen, "ID", "Grund", t_Spieler.FK_Bussen);
            return View(t_Spieler);
        }

        // GET: Spieler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Spieler t_Spieler = db.T_Spieler.Find(id);
            if (t_Spieler == null)
            {
                return HttpNotFound();
            }
            return View(t_Spieler);
        }

        // POST: Spieler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Spieler t_Spieler = db.T_Spieler.Find(id);
            db.T_Spieler.Remove(t_Spieler);
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
