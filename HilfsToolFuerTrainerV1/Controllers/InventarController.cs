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
    public class InventarController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: Inventar
        public ActionResult Index()
        {
            return View(db.T_Inventar.ToList());
        }

        // GET: Inventar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Inventar t_Inventar = db.T_Inventar.Find(id);
            if (t_Inventar == null)
            {
                return HttpNotFound();
            }
            return View(t_Inventar);
        }

        // GET: Inventar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventar/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung,Anzahl,Kommentar,FK_Mannschaft")] T_Inventar t_Inventar)
        {
            if (ModelState.IsValid)
            {
                db.T_Inventar.Add(t_Inventar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Inventar);
        }

        // GET: Inventar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Inventar t_Inventar = db.T_Inventar.Find(id);
            if (t_Inventar == null)
            {
                return HttpNotFound();
            }
            return View(t_Inventar);
        }

        // POST: Inventar/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung,Anzahl,Kommentar,FK_Mannschaft")] T_Inventar t_Inventar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Inventar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Inventar);
        }

        // GET: Inventar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Inventar t_Inventar = db.T_Inventar.Find(id);
            if (t_Inventar == null)
            {
                return HttpNotFound();
            }
            return View(t_Inventar);
        }

        // POST: Inventar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Inventar t_Inventar = db.T_Inventar.Find(id);
            db.T_Inventar.Remove(t_Inventar);
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
