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
    public class SpielBerichtsController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: SpielBerichts
        [Authorize]
        public ActionResult Index()
        {
            return View(db.SpielBericht.ToList());
        }

        // GET: SpielBerichts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpielBericht spielBericht = db.SpielBericht.Find(id);
            if (spielBericht == null)
            {
                return HttpNotFound();
            }
            return View(spielBericht);
        }

        // GET: SpielBerichts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpielBerichts/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VereinsNamen,SpielOrt,Taktik,Benotung,Bericht,FK_Mannschaft")] SpielBericht spielBericht)
        {
            if (ModelState.IsValid)
            {
                db.SpielBericht.Add(spielBericht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spielBericht);
        }

        // GET: SpielBerichts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpielBericht spielBericht = db.SpielBericht.Find(id);
            if (spielBericht == null)
            {
                return HttpNotFound();
            }
            return View(spielBericht);
        }

        // POST: SpielBerichts/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VereinsNamen,SpielOrt,Taktik,Benotung,Bericht,FK_Mannschaft")] SpielBericht spielBericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spielBericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spielBericht);
        }

        // GET: SpielBerichts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpielBericht spielBericht = db.SpielBericht.Find(id);
            if (spielBericht == null)
            {
                return HttpNotFound();
            }
            return View(spielBericht);
        }

        // POST: SpielBerichts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpielBericht spielBericht = db.SpielBericht.Find(id);
            db.SpielBericht.Remove(spielBericht);
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
