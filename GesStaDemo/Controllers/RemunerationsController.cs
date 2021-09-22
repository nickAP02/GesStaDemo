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
    public class RemunerationsController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Remunerations
        public ActionResult Index()
        {
            var remunerations = db.Remunerations.Include(r => r.Stagiaire);
            return View(remunerations.ToList());
        }

        // GET: Remunerations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remuneration remuneration = db.Remunerations.Find(id);
            if (remuneration == null)
            {
                return HttpNotFound();
            }
            return View(remuneration);
        }

        // GET: Remunerations/Create
        public ActionResult Create()
        {
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta");
            return View();
        }

        // POST: Remunerations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodRem,RegleMens,DateRemiz,IdSta")] Remuneration remuneration)
        {
            if (ModelState.IsValid)
            {
                db.Remunerations.Add(remuneration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", remuneration.IdSta);
            return View(remuneration);
        }

        // GET: Remunerations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remuneration remuneration = db.Remunerations.Find(id);
            if (remuneration == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", remuneration.IdSta);
            return View(remuneration);
        }

        // POST: Remunerations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodRem,RegleMens,DateRemiz,IdSta")] Remuneration remuneration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remuneration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", remuneration.IdSta);
            return View(remuneration);
        }

        // GET: Remunerations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remuneration remuneration = db.Remunerations.Find(id);
            if (remuneration == null)
            {
                return HttpNotFound();
            }
            return View(remuneration);
        }

        // POST: Remunerations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Remuneration remuneration = db.Remunerations.Find(id);
            db.Remunerations.Remove(remuneration);
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
