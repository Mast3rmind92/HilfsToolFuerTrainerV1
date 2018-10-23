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
    public class AnwesenheitController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: Anwesenheit
        public ActionResult Index()
        {
            return View(db.T_Anwesenheit.ToList());
        }

        // GET: Anwesenheit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Anwesenheit t_Anwesenheit = db.T_Anwesenheit.Find(id);
            if (t_Anwesenheit == null)
            {
                return HttpNotFound();
            }
            return View(t_Anwesenheit);
        }

        // GET: Anwesenheit/Create
        public ActionResult Create()
        {
            ViewBag.Spieler = db.T_Spieler.ToList();
            return View();
        }

        // POST: Anwesenheit/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung,Datum,istTraining")] T_Anwesenheit t_Anwesenheit)
        {
            ViewBag.Spieler = db.T_Spieler.ToList();
            if (ModelState.IsValid)
            {
                db.T_Anwesenheit.Add(t_Anwesenheit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Anwesenheit);
        }

        // GET: Anwesenheit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Anwesenheit t_Anwesenheit = db.T_Anwesenheit.Find(id);
            if (t_Anwesenheit == null)
            {
                return HttpNotFound();
            }
            return View(t_Anwesenheit);
        }

        // POST: Anwesenheit/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung,Datum,istTraining")] T_Anwesenheit t_Anwesenheit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Anwesenheit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Anwesenheit);
        }

        // GET: Anwesenheit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Anwesenheit t_Anwesenheit = db.T_Anwesenheit.Find(id);
            if (t_Anwesenheit == null)
            {
                return HttpNotFound();
            }
            return View(t_Anwesenheit);
        }

        // POST: Anwesenheit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Anwesenheit t_Anwesenheit = db.T_Anwesenheit.Find(id);
            db.T_Anwesenheit.Remove(t_Anwesenheit);
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
