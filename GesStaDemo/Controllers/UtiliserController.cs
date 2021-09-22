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
    public class UtiliserController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Utiliser
        public ActionResult Index()
        {
            var utilisers = db.Utilisers.Include(u => u.Materiel).Include(u => u.Stagiaire);
            return View(utilisers.ToList());
        }

        // GET: Utiliser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utiliser utiliser = db.Utilisers.Find(id);
            if (utiliser == null)
            {
                return HttpNotFound();
            }
            return View(utiliser);
        }

        // GET: Utiliser/Create
        public ActionResult Create()
        {
            ViewBag.CodMat = new SelectList(db.Materiels, "CodMat", "LibMat");
            //ViewBag.IdSta = Session["IdSta"];
            return View();
        }

        // POST: Utiliser/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateEmp,DateRet,CodMat")] Utiliser utiliser)
        {
            //var quer = db.Materiels.SqlQuery("select CodMat from Materiel");
            utiliser.IdSta = Convert.ToInt32(Session["IdSta"]);
            if (utiliser.DateEmp == utiliser.DateRet)
            {
                ModelState.AddModelError("", "La date de retrait doit être différente de la date d'emprunt");
                return View(utiliser);
            }
            if (utiliser.DateEmp > utiliser.DateRet)
            {
                ModelState.AddModelError("", "La date de retrait doit être supérieur à de la date d'emprunt");
                return View(utiliser);
            }
            if (utiliser.DateEmp.Year != DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez entrer l'année courante");
                return View(utiliser);
            }
            if (utiliser.DateRet.Year != DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez entrer l'année courante");
                return View(utiliser);
            }
            System.Diagnostics.Debug.WriteLine("idstagiare "+ Session["IdSta"]);
            if (ModelState.IsValid)
            {
                db.Utilisers.Add(utiliser);
                db.SaveChanges();
                var quer = db.Database.SqlQuery<int>("select Count(u.CodMat) from Utiliser as u join Materiel as m on u.CodMat=m.CodMat").FirstOrDefault();
                //System.Diagnostics.Debug.WriteLine("Count "+ quer);
                var query = db.Database.SqlQuery<int>("select QuantMat from Materiel as m join Utiliser as u on m.CodMat=u.CodMat where m.CodMat='"+utiliser.CodMat+"'"); 
                if(quer<=Convert.ToInt32(query))
                {
                    var setDispo = db.Database.ExecuteSqlCommand("update Materiel set Disponible=" + quer + " where CodMat='" + utiliser.CodMat + "'");
                }
                ViewBag.CodMat = new SelectList(db.Materiels, "CodMat", "LibMat", utiliser.CodMat);
                return RedirectToAction("Index");
            }
            
            // ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", utiliser.IdSta);
            //ViewBag.IdSta = Session["IdSta"];
            return View(utiliser);
        }

        // GET: Utiliser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utiliser utiliser = db.Utilisers.Find(id);
            if (utiliser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodMat = new SelectList(db.Materiels, "CodMat", "LibMat", utiliser.CodMat);
           // ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", utiliser.IdSta);
            return View(utiliser);
        }

        // POST: Utiliser/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateEmp,DateRet,CodMat")] Utiliser utiliser)
        {
            if (utiliser.DateEmp == utiliser.DateRet)
            {
                ModelState.AddModelError("", "La date de retrait doit être différente de la date d'emprunt");
                return View(utiliser);
            }
            if (utiliser.DateEmp > utiliser.DateRet)
            {
                ModelState.AddModelError("", "La date de retrait doit être supérieur à de la date d'emprunt");
                return View(utiliser);
            }
            if(utiliser.DateEmp.Year !=DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez entrer l'année courante");
                return View(utiliser);
            }
            if (utiliser.DateRet.Year != DateTime.Today.Year)
            {
                ModelState.AddModelError("", "Veuillez entrer l'année courante");
                return View(utiliser);
            }
            if (ModelState.IsValid)
            {
                db.Entry(utiliser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodMat = new SelectList(db.Materiels, "CodMat", "LibMat", utiliser.CodMat);
            //ViewBag.IdSta = new SelectList(db.Stagiaires, "IdSta", "NomSta", utiliser.IdSta);
            return View(utiliser);
        }

        // GET: Utiliser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utiliser utiliser = db.Utilisers.Find(id);
            if (utiliser == null)
            {
                return HttpNotFound();
            }
            return View(utiliser);
        }

        // POST: Utiliser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utiliser utiliser = db.Utilisers.Find(id);
            db.Utilisers.Remove(utiliser);
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
            var st = db.Utilisers.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportUtiliser.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Utilisations.pdf");
        }
    }
}
