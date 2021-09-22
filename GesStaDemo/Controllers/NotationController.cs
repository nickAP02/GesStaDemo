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
    public class NotationController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Notation
        public ActionResult Index()
        {
            return View(db.Notations.ToList());
        }

        // GET: Notation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notation notation = db.Notations.Find(id);
            if (notation == null)
            {
                return HttpNotFound();
            }
            return View(notation);
        }

        // GET: Notation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notation/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNot,NotRapp,ObserEval,DateNot,IdSta,CodMS,CodRapp")] Notation notation)
        {
            if (notation.NotRapp < 0)
            {
                ModelState.AddModelError("", "La note doit être supérieure à 0");
                return View(notation);
            }
            if (ModelState.IsValid)
            {
                db.Notations.Add(notation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notation);
        }

        // GET: Notation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notation notation = db.Notations.Find(id);
            if (notation == null)
            {
                return HttpNotFound();
            }
            return View(notation);
        }

        // POST: Notation/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNot,NotRapp,ObserEval,DateNot,IdSta,CodMS,CodRapp")] Notation notation)
        {
            if (notation.NotRapp < 0)
            {
                ModelState.AddModelError("", "La note doit être supérieure à 0");
                return View(notation);
            }
            if (ModelState.IsValid)
            {
                db.Entry(notation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notation);
        }

        // GET: Notation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notation notation = db.Notations.Find(id);
            if (notation == null)
            {
                return HttpNotFound();
            }
            return View(notation);
        }

        // POST: Notation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notation notation = db.Notations.Find(id);
            db.Notations.Remove(notation);
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
            var st = db.Notations.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportNot.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Notations.pdf");
        }
    }
}
