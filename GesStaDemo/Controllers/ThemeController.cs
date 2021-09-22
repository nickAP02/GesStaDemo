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
    public class ThemeController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Theme
        public ActionResult Index()
        {
            var themes = db.Themes.Include(t => t.MaitreDeStage).Include(t => t.Stagiaire);
            return View(themes.ToList());
        }

        // GET: Theme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // GET: Theme/Create
        public ActionResult Create()
        {
            ViewBag.CodMS = new SelectList(db.MaitreDeStages, "CodMS", "NomMS");
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta");
            return View();
        }

        // POST: Theme/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdThe,DateTheme,LibTheme,Objectifs,CodMS,IdSta")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                db.Themes.Add(theme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodMS = new SelectList(db.MaitreDeStages, "CodMS", "NomMS", theme.CodMS);
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", theme.IdSta);
            return View(theme);
        }

        // GET: Theme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodMS = new SelectList(db.MaitreDeStages, "CodMS", "NomMS", theme.CodMS);
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", theme.IdSta);
            return View(theme);
        }

        // POST: Theme/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdThe,DateTheme,LibTheme,Objectifs,CodMS,IdSta")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodMS = new SelectList(db.MaitreDeStages, "CodMS", "NomMS", theme.CodMS);
            ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", theme.IdSta);
            return View(theme);
        }

        // GET: Theme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // POST: Theme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theme theme = db.Themes.Find(id);
            db.Themes.Remove(theme);
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
            var st = db.Themes.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/Theme.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Themes.pdf");
        }
    }
}
