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
    public class AvoirPourController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: AvoirPour
        public ActionResult Index()
        {
            var avoirPours = db.AvoirPours.Include(a => a.Stagiaire).Include(a => a.Superviseur);
            return View(avoirPours.ToList());
        }

        // GET: AvoirPour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvoirPour avoirPour = db.AvoirPours.Find(id);
            if (avoirPour == null)
            {
                return HttpNotFound();
            }
            return View(avoirPour);
        }

        // GET: AvoirPour/Create
        public ActionResult Create()
        {
            ViewBag.AvoirPourSup = new SelectList(db.Stagiaires, "IdSta", "NomSta");
            ViewBag.AvoirPourSta = new SelectList(db.Superviseurs, "IdSup", "NomSup");
            return View();
        }

        // POST: AvoirPour/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateSup,AvoirPourSup,AvoirPourSta")] AvoirPour avoirPour)
        {
            if (avoirPour.DateSup.Year != DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez entrer l'année courante");
                return View(avoirPour);
            }
            if (ModelState.IsValid)
            {
                db.AvoirPours.Add(avoirPour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AvoirPourSup = new SelectList(db.Stagiaires, "IdSta", "NomSta", avoirPour.AvoirPourSup);
            ViewBag.AvoirPourSta = new SelectList(db.Superviseurs, "IdSup", "NomSup", avoirPour.AvoirPourSta);
            return View(avoirPour);
        }

        // GET: AvoirPour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvoirPour avoirPour = db.AvoirPours.Find(id);
            if (avoirPour == null)
            {
                return HttpNotFound();
            }
            ViewBag.AvoirPourSup = new SelectList(db.Stagiaires, "IdSta", "NomSta", avoirPour.AvoirPourSup);
            ViewBag.AvoirPourSta = new SelectList(db.Superviseurs, "IdSup", "NomSup", avoirPour.AvoirPourSta);
            return View(avoirPour);
        }

        // POST: AvoirPour/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateSup,AvoirPourSup,AvoirPourSta")] AvoirPour avoirPour)
        {
            if (avoirPour.DateSup.Year != DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez entrer l'année courante");
                return View(avoirPour);
            }
            if (ModelState.IsValid)
            {
                db.Entry(avoirPour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AvoirPourSup = new SelectList(db.Stagiaires, "IdSta", "NomSta", avoirPour.AvoirPourSup);
            ViewBag.AvoirPourSta = new SelectList(db.Superviseurs, "IdSup", "NomSup", avoirPour.AvoirPourSta);
            return View(avoirPour);
        }

        // GET: AvoirPour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvoirPour avoirPour = db.AvoirPours.Find(id);
            if (avoirPour == null)
            {
                return HttpNotFound();
            }
            return View(avoirPour);
        }

        // POST: AvoirPour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvoirPour avoirPour = db.AvoirPours.Find(id);
            db.AvoirPours.Remove(avoirPour);
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
