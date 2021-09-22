using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GesStaDemo;
using GesStaDemo.Models.Entities;

namespace GesStaDemo.Controllers
{
    public class DroitController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Droit
        public ActionResult Index()
        {
            var droits = db.Droits.Include(d => d.Profil).Include(d => d.Utilisateur);
            return View(droits.ToList());
        }

        // GET: Droit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Droit droit = db.Droits.Find(id);
            if (droit == null)
            {
                return HttpNotFound();
            }
            return View(droit);
        }

        // GET: Droit/Create
        public ActionResult Create()
        {
            ViewBag.ProfilId = new SelectList(db.Profils, "ProfilId", "LibProfil");
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login");
            return View();
        }

        // POST: Droit/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DroitId,UtilId,ProfilId")] Droit droit)
        {
            if (ModelState.IsValid)
            {
                db.Droits.Add(droit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfilId = new SelectList(db.Profils, "ProfilId", "LibProfil", droit.ProfilId);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", droit.UtilId);
            return View(droit);
        }

        // GET: Droit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Droit droit = db.Droits.Find(id);
            if (droit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfilId = new SelectList(db.Profils, "ProfilId", "LibProfil", droit.ProfilId);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", droit.UtilId);
            return View(droit);
        }

        // POST: Droit/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DroitId,UtilId,ProfilId")] Droit droit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(droit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfilId = new SelectList(db.Profils, "ProfilId", "LibProfil", droit.ProfilId);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", droit.UtilId);
            return View(droit);
        }

        // GET: Droit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Droit droit = db.Droits.Find(id);
            if (droit == null)
            {
                return HttpNotFound();
            }
            return View(droit);
        }

        // POST: Droit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Droit droit = db.Droits.Find(id);
            db.Droits.Remove(droit);
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
