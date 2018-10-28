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
    public class EventController : Controller
    {
        private HilfsToolfuerTrainerEntities db = new HilfsToolfuerTrainerEntities();

        // GET: Event
        [Authorize]
        public ActionResult Index()
        {
            return View(db.T_Event.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Event t_Event = db.T_Event.Find(id);
            if (t_Event == null)
            {
                return HttpNotFound();
            }
            return View(t_Event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung,Datum,FK_Mannschaft")] T_Event t_Event)
        {
            if (ModelState.IsValid)
            {
                db.T_Event.Add(t_Event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Event);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Event t_Event = db.T_Event.Find(id);
            if (t_Event == null)
            {
                return HttpNotFound();
            }
            return View(t_Event);
        }

        // POST: Event/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung,Datum,FK_Mannschaft")] T_Event t_Event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Event);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Event t_Event = db.T_Event.Find(id);
            if (t_Event == null)
            {
                return HttpNotFound();
            }
            return View(t_Event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Event t_Event = db.T_Event.Find(id);
            db.T_Event.Remove(t_Event);
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
