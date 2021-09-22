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
    public class FormationController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Formation
        public ActionResult Index()
        {
            var formations = db.Formations.Include(f => f.Section).Include(f => f.Stagiaire);
            return View(formations.ToList());
        }

        // GET: Formation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // GET: Formation/Create
        public ActionResult Create()
        {
            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec");
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta");
            return View();
        }

        // POST: Formation/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFor,DateAffectation,IdSta,CodSec")] Formation formation)
        {
            if(formation.DateAffectation.Year!=DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez choisir l'année courante");
                return View(formation);
            }
            if (ModelState.IsValid)
            {
                db.Formations.Add(formation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec", formation.CodSec);
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", formation.IdSta);
            return View(formation);
        }

        // GET: Formation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec", formation.CodSec);
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", formation.IdSta);
            return View(formation);
        }

        // POST: Formation/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFor,DateAffectation,IdSta,CodSec")] Formation formation)
        {
            if (formation.DateAffectation.Year != DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez choisir l'année courante");
                return View(formation);
            }
            if (ModelState.IsValid)
            {
                db.Entry(formation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec", formation.CodSec);
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", formation.IdSta);
            return View(formation);
        }

        // GET: Formation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formation formation = db.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: Formation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formation formation = db.Formations.Find(id);
            db.Formations.Remove(formation);
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
            var formations = db.Formations.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportFormation.rpt")));
            rd.SetDataSource(formations);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Formations.pdf");
        }
    }
}
