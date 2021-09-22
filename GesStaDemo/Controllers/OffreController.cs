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
    public class OffreController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Offre
        public ActionResult Index()
        {
            return View(db.Offres.ToList());
        }

        // GET: Offre/Details/5
        public ActionResult Details(int id)
        {
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // GET: Offre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offre/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OffreId,LibOffre,DebutStage,FinStage,Remunerer")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                if (offre.DebutStage.Date > offre.FinStage.Date)
                {
                    ModelState.AddModelError("", "La date de fin doit être supérieur à la date de début");
                    return View();
                }
                if (offre.DebutStage.Date == offre.FinStage.Date)
                {
                    ModelState.AddModelError("", "La date de fin doit être diiférente de la date de début");
                    return View();
                }
                if ((offre.FinStage.Subtract(offre.DebutStage)).TotalDays < 30)
                {
                    ModelState.AddModelError("", "La durée minimale d'un stage est de 30 jours");
                    return View(offre);
                }
                if (offre.DebutStage.Date < offre.FinStage.Date || offre.FinStage.Subtract(offre.DebutStage).TotalDays >= 30)
                {
                    db.Offres.Add(offre);
                    db.SaveChanges();
                    return RedirectToAction("Liste", "Admin");

                }

            }

            return View(offre);
        }

        // GET: Offre/Edit/5
        public ActionResult Edit(int id)
        {
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offre/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OffreId,LibOffre,DebutStage,FinStage,Remunerer")] Offre offre)
        {    
            System.Diagnostics.Debug.WriteLine(offre.FinStage.Subtract(offre.DebutStage));
            if (ModelState.IsValid)
            {
                if (offre.DebutStage.Date > offre.FinStage.Date)
                {
                    ModelState.AddModelError("", "La date de fin doit être supérieur à la date de début");
                    return View(offre);
                }
                if (offre.DebutStage.Date == offre.FinStage.Date)
                {
                    ModelState.AddModelError("", "La date de fin doit être diiférente de la date de début");
                    return View(offre);
                }
                if ((offre.FinStage.Subtract(offre.DebutStage)).TotalDays < 30)
                {
                    ModelState.AddModelError("", "La durée minimale d'un stage est de 30 jours");
                    return View(offre);
                }
                if (offre.DebutStage < offre.FinStage || offre.FinStage.Subtract(offre.DebutStage).TotalDays >= 30)
                {
                    db.Entry(offre).State = EntityState.Modified;
                    db.Offres.Add(offre);
                    db.SaveChanges();
                    return RedirectToAction("Liste", "Admin");

                }
            }
            
            return View(offre);
        }

        // GET: Offre/Delete/5
        public ActionResult Delete(int id)
        {
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = db.Offres.Find(id);
            db.Offres.Remove(offre);
            db.SaveChanges();
            return RedirectToAction("Liste", "Admin");
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
