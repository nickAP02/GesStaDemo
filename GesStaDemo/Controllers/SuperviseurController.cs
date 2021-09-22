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
    public class SuperviseurController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Superviseur
        public ActionResult Index()
        {
            var superviseurs = db.Superviseurs.Include(s => s.Utilisateur);
            return View(superviseurs.ToList());
        }

        // GET: Superviseur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superviseur superviseur = db.Superviseurs.Find(id);
            if (superviseur == null)
            {
                return HttpNotFound();
            }
            return View(superviseur);
        }

        // GET: Superviseur/Create
        public ActionResult Create()
        {
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login");
            return View();
        }

        // POST: Superviseur/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSup,NomSup,PrenSup,AdrSup,TelSup,UtilId")] Superviseur superviseur)
        {
            if (ModelState.IsValid)
            {
                db.Superviseurs.Add(superviseur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", superviseur.UtilId);
            return View(superviseur);
        }

        // GET: Superviseur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superviseur superviseur = db.Superviseurs.Find(id);
            if (superviseur == null)
            {
                return HttpNotFound();
            }
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", superviseur.UtilId);
            return View(superviseur);
        }

        // POST: Superviseur/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSup,NomSup,PrenSup,AdrSup,TelSup,UtilId")] Superviseur superviseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superviseur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", superviseur.UtilId);
            return View(superviseur);
        }

        // GET: Superviseur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superviseur superviseur = db.Superviseurs.Find(id);
            if (superviseur == null)
            {
                return HttpNotFound();
            }
            return View(superviseur);
        }

        // POST: Superviseur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Superviseur superviseur = db.Superviseurs.Find(id);
            db.Superviseurs.Remove(superviseur);
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
            var st = db.Superviseurs.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportSup.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Superviseurs.pdf");
        }
    }
}
