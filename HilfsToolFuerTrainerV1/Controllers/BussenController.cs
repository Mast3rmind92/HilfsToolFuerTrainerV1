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
    public class BussenController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: Bussen
        public ActionResult Index()
        {
            var t_Bussen = db.T_Bussen.Include(t => t.T_Spieler1);
            return View(t_Bussen.ToList());
        }

        // GET: Bussen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Bussen t_Bussen = db.T_Bussen.Find(id);
            if (t_Bussen == null)
            {
                return HttpNotFound();
            }
            return View(t_Bussen);
        }

        // GET: Bussen/Create
        public ActionResult Create()
        {
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname");
            return View();
        }

        // POST: Bussen/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Grund,Betrag,istBezahlt,FK_Spieler")] T_Bussen t_Bussen)
        {
            if (ModelState.IsValid)
            {
                db.T_Bussen.Add(t_Bussen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Bussen.FK_Spieler);
            return View(t_Bussen);
        }

        // GET: Bussen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Bussen t_Bussen = db.T_Bussen.Find(id);
            if (t_Bussen == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Bussen.FK_Spieler);
            return View(t_Bussen);
        }

        // POST: Bussen/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Grund,Betrag,istBezahlt,FK_Spieler")] T_Bussen t_Bussen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Bussen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Spieler = new SelectList(db.T_Spieler, "ID", "Vorname", t_Bussen.FK_Spieler);
            return View(t_Bussen);
        }

        // GET: Bussen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Bussen t_Bussen = db.T_Bussen.Find(id);
            if (t_Bussen == null)
            {
                return HttpNotFound();
            }
            return View(t_Bussen);
        }

        // POST: Bussen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Bussen t_Bussen = db.T_Bussen.Find(id);
            db.T_Bussen.Remove(t_Bussen);
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
