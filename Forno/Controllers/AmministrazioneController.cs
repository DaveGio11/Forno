using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forno.Models;

namespace Forno.Controllers
{
    public class AmministrazioneController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Amministrazione
        public ActionResult Index()
        {
            return View(db.Amministrazione.ToList());
        }

        // GET: Amministrazione/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amministrazione amministrazione = db.Amministrazione.Find(id);
            if (amministrazione == null)
            {
                return HttpNotFound();
            }
            return View(amministrazione);
        }

        // GET: Amministrazione/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amministrazione/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Admin,Username,Password,Ruolo")] Amministrazione amministrazione)
        {
            if (ModelState.IsValid)
            {
                db.Amministrazione.Add(amministrazione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amministrazione);
        }

        // GET: Amministrazione/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amministrazione amministrazione = db.Amministrazione.Find(id);
            if (amministrazione == null)
            {
                return HttpNotFound();
            }
            return View(amministrazione);
        }

        // POST: Amministrazione/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Admin,Username,Password,Ruolo")] Amministrazione amministrazione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amministrazione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amministrazione);
        }

        // GET: Amministrazione/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amministrazione amministrazione = db.Amministrazione.Find(id);
            if (amministrazione == null)
            {
                return HttpNotFound();
            }
            return View(amministrazione);
        }

        // POST: Amministrazione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amministrazione amministrazione = db.Amministrazione.Find(id);
            db.Amministrazione.Remove(amministrazione);
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
