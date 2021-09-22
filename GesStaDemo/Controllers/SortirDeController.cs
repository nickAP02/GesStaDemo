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
    public class SortirDeController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: SortirDe
        public ActionResult Index()
        {
            return View(db.SortirDes.ToList());
        }

        // GET: SortirDe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SortirDe sortirDe = db.SortirDes.Find(id);
            if (sortirDe == null)
            {
                return HttpNotFound();
            }
            return View(sortirDe);
        }

        // GET: SortirDe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SortirDe/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DatePro,NivoEtude")] SortirDe sortirDe)
        {
            if (sortirDe.DatePro == DateTime.Today)
            {
                ModelState.AddModelError("", "La date de provenance doit être différente de la date d'aujourd'hui");
                return View(sortirDe);
            }
            if (ModelState.IsValid)
            {
                db.SortirDes.Add(sortirDe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sortirDe);
        }

        // GET: SortirDe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SortirDe sortirDe = db.SortirDes.Find(id);
            if (sortirDe == null)
            {
                return HttpNotFound();
            }
            return View(sortirDe);
        }

        // POST: SortirDe/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DatePro,NivoEtude")] SortirDe sortirDe)
        {
            if (sortirDe.DatePro == DateTime.Today)
            {
                ModelState.AddModelError("", "La date de provenance doit être différente de la date d'aujourd'hui");
                return View(sortirDe);
            }
            if (ModelState.IsValid)
            {
                db.Entry(sortirDe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sortirDe);
        }

        // GET: SortirDe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SortirDe sortirDe = db.SortirDes.Find(id);
            if (sortirDe == null)
            {
                return HttpNotFound();
            }
            return View(sortirDe);
        }

        // POST: SortirDe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SortirDe sortirDe = db.SortirDes.Find(id);
            db.SortirDes.Remove(sortirDe);
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
            var st = db.SortirDes.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportSort.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Sorties.pdf");
        }
    }
}
