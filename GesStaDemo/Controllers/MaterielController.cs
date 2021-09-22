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
    public class MaterielController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Materiel
        public ActionResult Index()
        {

            return View(db.Materiels.ToList());
        }

        // GET: Materiel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            return View(materiel);
        }

        // GET: Materiel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materiel/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodMat,LibMat,QuantMat,Caracteristik,Disponible")] Materiel materiel)
        {
            if (materiel.QuantMat < 0)
            {
                ModelState.AddModelError("", "La quantité doit être supérieure à 0");
                return View(materiel);
            }
            if(materiel.QuantMat == 0)
            {
                ModelState.AddModelError("", "La quantité doit être différente de 0");
                return View(materiel);
            }
            /* materiel.Disponible = materiel.QuantMat;
             var quer = db.Database.SqlQuery<int>("select Count(CodMat) from Utiliser as u join Materiel as m on u.CodMat=m.CodMat").FirstOrDefault();
             System.Diagnostics.Debug.WriteLine(quer);
             if(materiel.QuantMat>=quer)
             {
                 materiel.Disponible = materiel.QuantMat-quer;
                 if (ModelState.IsValid)
             {
                 db.Materiels.Add(materiel);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             }*/
            if (ModelState.IsValid)
            {
                db.Materiels.Add(materiel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Disponible = materiel.Disponible;
            return View(materiel);
        }

        // GET: Materiel/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            return View(materiel);
        }

        // POST: Materiel/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodMat,LibMat,QuantMat,Caracteristik,Disponible")] Materiel materiel)
        {
            if (materiel.QuantMat < 0)
            {
                ModelState.AddModelError("", "La quantité doit être supérieure à 0");
                return View(materiel);
            }
            if (materiel.Disponible < 0)
            {
                ModelState.AddModelError("", "La quantité disponible doit être supérieure à 0");
                return View(materiel);
            }
            //materiel.Disponible = materiel.QuantMat;
            if (ModelState.IsValid)
            {
                db.Entry(materiel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.Disponible = materiel.Disponible;
            return View(materiel);
        }

        // GET: Materiel/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            return View(materiel);
        }

        // POST: Materiel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Materiel materiel = db.Materiels.Find(id);
            db.Materiels.Remove(materiel);
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
            var st = db.Materiels.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportMat.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Materiels.pdf");
        }
    }
}
