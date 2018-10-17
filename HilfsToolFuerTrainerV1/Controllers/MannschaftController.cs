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
    public class MannschaftController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: Mannschaft
        public ActionResult Index()
        {
            var t_Mannschaft = db.T_Mannschaft.Include(t => t.T_Event).Include(t => t.T_Inventar).Include(t => t.T_Spieler);
            return View(t_Mannschaft.ToList());
        }

        // GET: Mannschaft/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Mannschaft t_Mannschaft = db.T_Mannschaft.Find(id);
            if (t_Mannschaft == null)
            {
                return HttpNotFound();
            }
            return View(t_Mannschaft);
        }

        // GET: Mannschaft/Create
        public ActionResult Create()
        {
            ViewBag.FK_Event = new SelectList(db.T_Event, "ID", "Bezeichnung");
            ViewBag.FK_Inventar = new SelectList(db.T_Inventar, "ID", "Bezeichnung");
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname");
            return View();
        }

        // POST: Mannschaft/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Spieler,FK_Inventar,FK_Event")] T_Mannschaft t_Mannschaft)
        {
            if (ModelState.IsValid)
            {
                db.T_Mannschaft.Add(t_Mannschaft);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Event = new SelectList(db.T_Event, "ID", "Bezeichnung", t_Mannschaft.FK_Event);
            ViewBag.FK_Inventar = new SelectList(db.T_Inventar, "ID", "Bezeichnung", t_Mannschaft.FK_Inventar);
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Mannschaft.FK_Spieler);
            return View(t_Mannschaft);
        }

        // GET: Mannschaft/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Mannschaft t_Mannschaft = db.T_Mannschaft.Find(id);
            if (t_Mannschaft == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Event = new SelectList(db.T_Event, "ID", "Bezeichnung", t_Mannschaft.FK_Event);
            ViewBag.FK_Inventar = new SelectList(db.T_Inventar, "ID", "Bezeichnung", t_Mannschaft.FK_Inventar);
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Mannschaft.FK_Spieler);
            return View(t_Mannschaft);
        }

        // POST: Mannschaft/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Spieler,FK_Inventar,FK_Event")] T_Mannschaft t_Mannschaft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Mannschaft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Event = new SelectList(db.T_Event, "ID", "Bezeichnung", t_Mannschaft.FK_Event);
            ViewBag.FK_Inventar = new SelectList(db.T_Inventar, "ID", "Bezeichnung", t_Mannschaft.FK_Inventar);
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Mannschaft.FK_Spieler);
            return View(t_Mannschaft);
        }

        // GET: Mannschaft/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Mannschaft t_Mannschaft = db.T_Mannschaft.Find(id);
            if (t_Mannschaft == null)
            {
                return HttpNotFound();
            }
            return View(t_Mannschaft);
        }

        // POST: Mannschaft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Mannschaft t_Mannschaft = db.T_Mannschaft.Find(id);
            db.T_Mannschaft.Remove(t_Mannschaft);
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
