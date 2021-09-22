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
    public class RapportController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Rapport
        public ActionResult Index()
        {
            return View(db.Rapports.ToList());
        }

        // GET: Rapport/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rapport rapport = db.Rapports.Find(id);
            if (rapport == null)
            {
                return HttpNotFound();
            }
            return View(rapport);
        }

        // GET: Rapport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rapport/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodRapp,NomRapp,Taches,DatePresentat")] Rapport rapport)
        {
            if(rapport.DatePresentat.Year!=DateTime.Today.Year)
            {
                ModelState.AddModelError("", "L'année de présentation doit être l'année courante");
                return View(rapport);
            }
            if (ModelState.IsValid)
            {
                db.Rapports.Add(rapport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rapport);
        }

        // GET: Rapport/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rapport rapport = db.Rapports.Find(id);
            if (rapport == null)
            {
                return HttpNotFound();
            }
            return View(rapport);
        }

        // POST: Rapport/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodRapp,NomRapp,Taches,DatePresentat")] Rapport rapport)
        {
            if (rapport.DatePresentat.Year != DateTime.Today.Year)
            {
                ModelState.AddModelError("", "L'année de présentation doit être l'année courante");
                return View(rapport);
            }
            if (ModelState.IsValid)
            {
                db.Entry(rapport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rapport);
        }

        // GET: Rapport/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rapport rapport = db.Rapports.Find(id);
            if (rapport == null)
            {
                return HttpNotFound();
            }
            return View(rapport);
        }

        // POST: Rapport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Rapport rapport = db.Rapports.Find(id);
            db.Rapports.Remove(rapport);
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
            var st = db.Rapports.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportRap.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Rapports.pdf");
        }
    }
}
