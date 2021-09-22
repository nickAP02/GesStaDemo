using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using GesStaDemo;
using GesStaDemo.Models.Entities;

namespace GesStaDemo.Controllers
{
    public class RemunerationController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Remuneration
        public ActionResult Index()
        {
            var remunerations = db.Remunerations.Include(r => r.Stagiaire);
            return View(remunerations.ToList());
        }

        // GET: Remuneration/Details/5
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

        // GET: Remuneration/Create
        public ActionResult Create()
        {
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta");
            return View();
        }

        // POST: Remuneration/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodRem,RegleMens,DateRemiz,IdSta")] Remuneration remuneration)
        {
            if(remuneration.RegleMens < 0)
            {
                ModelState.AddModelError("", "Le montant du règlement doit être supérieur à 0");
                return View(remuneration);
            }
            if(remuneration.DateRemiz.Year!=DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez choisir l'année courante");
                return View(remuneration);
            }
            if (ModelState.IsValid)
            {
                db.Remunerations.Add(remuneration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", remuneration.IdSta);
            return View(remuneration);
        }

        // GET: Remuneration/Edit/5
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

        // POST: Remuneration/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodRem,RegleMens,DateRemiz")] Remuneration remuneration)
        {
            if (remuneration.RegleMens < 0)
            {
                ModelState.AddModelError("", "Le montant du règlement doit être supérieur à 0");
                return View(remuneration);
            }
            if (ModelState.IsValid)
            {
                db.Entry(remuneration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", remuneration.IdSta);
            return View(remuneration);
        }

        // GET: Remuneration/Delete/5
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

        // POST: Remuneration/Delete/5
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
        public ActionResult Imprimer()
        {
            var st = db.Remunerations.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportRem.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Remunerations.pdf");
        }
    }
}
