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
    public class ProvenanceController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Provenance
        public ActionResult Index()
        {
            return View(db.Provenances.ToList());
        }

        // GET: Provenance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provenance provenance = db.Provenances.Find(id);
            if (provenance == null)
            {
                return HttpNotFound();
            }
            return View(provenance);
        }

        // GET: Provenance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provenance/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProv,LibProv,AdrProv,VilleProv")] Provenance provenance)
        {
            if (ModelState.IsValid)
            {
                db.Provenances.Add(provenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provenance);
        }

        // GET: Provenance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provenance provenance = db.Provenances.Find(id);
            if (provenance == null)
            {
                return HttpNotFound();
            }
            return View(provenance);
        }

        // POST: Provenance/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProv,LibProv,AdrProv,VilleProv")] Provenance provenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provenance);
        }

        // GET: Provenance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provenance provenance = db.Provenances.Find(id);
            if (provenance == null)
            {
                return HttpNotFound();
            }
            return View(provenance);
        }

        // POST: Provenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provenance provenance = db.Provenances.Find(id);
            db.Provenances.Remove(provenance);
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
            var st = db.Stagiaires.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportProv.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Provenances.pdf");
        }
    }
}
