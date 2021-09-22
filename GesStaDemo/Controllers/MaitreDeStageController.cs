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
    public class MaitreDeStageController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: MaitreDeStage
        public ActionResult Index()
        {
            var maitreDeStages = db.MaitreDeStages.Include(m => m.Section).Include(m => m.Utilisateur);
            return View(maitreDeStages.ToList());
        }

        // GET: MaitreDeStage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitreDeStage maitreDeStage = db.MaitreDeStages.Find(id);
            if (maitreDeStage == null)
            {
                return HttpNotFound();
            }
            return View(maitreDeStage);
        }

        // GET: MaitreDeStage/Create
        public ActionResult Create()
        {
            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec");
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login");
            return View();
        }

        // POST: MaitreDeStage/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodMS,NomMS,PrenMS,TelMS,AdrMS,Fonction,CodSec,UtilId")] MaitreDeStage maitreDeStage)
        {
            if (ModelState.IsValid)
            {
                db.MaitreDeStages.Add(maitreDeStage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec", maitreDeStage.CodSec);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", maitreDeStage.UtilId);
            return View(maitreDeStage);
        }

        // GET: MaitreDeStage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitreDeStage maitreDeStage = db.MaitreDeStages.Find(id);
            if (maitreDeStage == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec", maitreDeStage.CodSec);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", maitreDeStage.UtilId);
            return View(maitreDeStage);
        }

        // POST: MaitreDeStage/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodMS,NomMS,PrenMS,TelMS,AdrMS,Fonction,CodSec,UtilId")] MaitreDeStage maitreDeStage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maitreDeStage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodSec = new SelectList(db.Sections, "CodSec", "LibSec", maitreDeStage.CodSec);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", maitreDeStage.UtilId);
            return View(maitreDeStage);
        }

        // GET: MaitreDeStage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaitreDeStage maitreDeStage = db.MaitreDeStages.Find(id);
            if (maitreDeStage == null)
            {
                return HttpNotFound();
            }
            return View(maitreDeStage);
        }

        // POST: MaitreDeStage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaitreDeStage maitreDeStage = db.MaitreDeStages.Find(id);
            db.MaitreDeStages.Remove(maitreDeStage);
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
            var ms = db.MaitreDeStages.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportMS.rpt")));
            rd.SetDataSource(ms);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "MaîtresDeStage.pdf");
        }
    }
}
