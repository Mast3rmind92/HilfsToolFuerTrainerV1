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
    public class AbsenzenController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: Absenzen
        [Authorize]
        public ActionResult Index()
        {
            var t_Absenzen = db.T_Absenzen.Include(t => t.T_Spieler1);
            return View(t_Absenzen.ToList());
        }

        // GET: Absenzen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Absenzen t_Absenzen = db.T_Absenzen.Find(id);
            if (t_Absenzen == null)
            {
                return HttpNotFound();
            }
            return View(t_Absenzen);
        }

        // GET: Absenzen/Create
        public ActionResult Create()
        {
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname");
            return View();
        }

        // POST: Absenzen/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung,VonDatum,BisDatum,FK_Spieler")] T_Absenzen t_Absenzen)
        {
            if (ModelState.IsValid)
            {
                db.T_Absenzen.Add(t_Absenzen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Absenzen.FK_Spieler);
            return View(t_Absenzen);
        }

        // GET: Absenzen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Absenzen t_Absenzen = db.T_Absenzen.Find(id);
            if (t_Absenzen == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Absenzen.FK_Spieler);
            return View(t_Absenzen);
        }

        // POST: Absenzen/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung,VonDatum,BisDatum,FK_Spieler")] T_Absenzen t_Absenzen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Absenzen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Absenzen.FK_Spieler);
            return View(t_Absenzen);
        }

        // GET: Absenzen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Absenzen t_Absenzen = db.T_Absenzen.Find(id);
            if (t_Absenzen == null)
            {
                return HttpNotFound();
            }
            return View(t_Absenzen);
        }

        // POST: Absenzen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Absenzen t_Absenzen = db.T_Absenzen.Find(id);
            db.T_Absenzen.Remove(t_Absenzen);
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
