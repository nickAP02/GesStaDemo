using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using GesStaDemo;
using GesStaDemo.Models.Entities;

namespace GesStaDemo.Controllers
{
    public class StagiaireController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Stagiaire
        public ActionResult Index()
        {
            var stagiaires = db.Stagiaires.Include(s => s.Provenance).Include(s => s.Utilisateur);
            return View(stagiaires.ToList());
        }

        // GET: Stagiaire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // GET: Stagiaire/Create
        public ActionResult Create()
        {
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login");
            ViewBag.IdProv = new SelectList(db.Provenances, "IdProv", "LibProv");
            return View();
        }

        // POST: Stagiaire/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSta,NomSta,PrenSta,TelSta,AdrSta,DebutStage,FinStage,NbRenouvel,Somm,NatSta,SexSta,DateNaisSta,CodRem,IdProv,UtilId")] Stagiaire stagiaire)
        {
            if (stagiaire.DebutStage.Date > stagiaire.FinStage.Date)
            {
                ModelState.AddModelError("", "La date de fin doit être supérieur à la date de début");
                return View();
            }
            if (stagiaire.DebutStage.Date == stagiaire.FinStage.Date)
            {
                ModelState.AddModelError("", "La date de fin doit être diiférente de la date de début");
                return View();
            }
            if ((stagiaire.FinStage.Subtract(stagiaire.DebutStage)).TotalDays < 30)
            {
                ModelState.AddModelError("", "La durée minimale d'un stage est de 30 jours");
                return View(stagiaire);
            }
            if (stagiaire.DateNaisSta == DateTime.Today.Date)
            {
                ModelState.AddModelError("", "Veuillez choisir une date différente de la date d'aujourd'hui");
                return View(stagiaire);
            }
            if (stagiaire.DateNaisSta == DateTime.Today.AddYears(0))
            {
                ModelState.AddModelError("", "Veuillez choisir une année différente de l'année courante");
                return View(stagiaire);
            }
            var moydate = DateTime.Today.AddYears(-18);
            if (stagiaire.DateNaisSta <= DateTime.Today.AddYears(-1) && stagiaire.DateNaisSta >= moydate)
            {
                ModelState.AddModelError("", "Un stagiaire doit avoir au moins 18 ans");
                return View();
            }
            if (stagiaire.SexSta == null)
            {
                ModelState.AddModelError("", "Le champ sexe est obligatoire");
                return View(stagiaire);
            }
            
            db.Stagiaires.Add(stagiaire);
            System.Diagnostics.Debug.WriteLine(stagiaire.Somm);
            db.SaveChanges();
            return RedirectToAction("Index");
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login",stagiaire.UtilId);
            ViewBag.IdProv = new SelectList(db.Provenances, "IdProv", "LibProv",stagiaire.IdProv);
            return View(stagiaire);
        }

        // GET: Stagiaire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodRem = new SelectList(db.Remunerations, "CodRem", "CodRem", stagiaire.CodRem);
            ViewBag.IdProv = new SelectList(db.Provenances, "IdProv", "LibProv", stagiaire.IdProv);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", stagiaire.UtilId);
            return View(stagiaire);
        }

        // POST: Stagiaire/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSta,NomSta,PrenSta,TelSta,AdrSta,DebutStage,FinStage,NbRenouvel,Somm,NatSta,SexSta,DateNaisSta,CodRem,IdProv,UtilId")] Stagiaire stagiaire)
        {
            if (stagiaire.DebutStage.Date > stagiaire.FinStage.Date)
            {
                ModelState.AddModelError("", "La date de fin doit être supérieur à la date de début");
                return View();
            }
            if (stagiaire.DebutStage.Date == stagiaire.FinStage.Date)
            {
                ModelState.AddModelError("", "La date de fin doit être diiférente de la date de début");
                return View();
            }
            if ((stagiaire.FinStage.Subtract(stagiaire.DebutStage)).TotalDays < 30)
            {
                ModelState.AddModelError("", "La durée minimale d'un stage est de 30 jours");
                return View(stagiaire);
            }
            if (stagiaire.DateNaisSta == DateTime.Today.Date)
            {
                ModelState.AddModelError("", "Veuillez choisir une date différente de la date d'aujourd'hui");
                return View(stagiaire);
            }
            if (stagiaire.DateNaisSta == DateTime.Today.AddYears(0))
            {
                ModelState.AddModelError("", "Veuillez choisir une année différente de l'année courante");
                return View(stagiaire);
            }
            var moydate = DateTime.Today.AddYears(-18);
            if (stagiaire.DateNaisSta <= DateTime.Today.AddYears(-1) && stagiaire.DateNaisSta >= moydate)
            {
                ModelState.AddModelError("", "Un stagiaire doit avoir au moins 18 ans");
                return View();
            }
            if (stagiaire.SexSta == null)
            {
                ModelState.AddModelError("", "Le champ sexe est obligatoire");
                return View(stagiaire);
            }
            if (ModelState.IsValid)
            {
                db.Entry(stagiaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodRem = new SelectList(db.Remunerations, "CodRem", "CodRem", stagiaire.CodRem);
            ViewBag.IdProv = new SelectList(db.Provenances, "IdProv", "LibProv", stagiaire.IdProv);
            ViewBag.UtilId = new SelectList(db.Utilisateurs, "UtilId", "Login", stagiaire.UtilId);
            return View(stagiaire);
        }

        // GET: Stagiaire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // POST: Stagiaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            db.Stagiaires.Remove(stagiaire);
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
        /*public ActionResult Renouvellement()
        {
            MailMessage message = new MailMessage();
            var from=db.Database.SqlQuery<string>("select Email from where IdSta="+ Convert.ToInt32(Session["IdSta"])+"").FirstOrDefault();
            message.From = ""+from+"";
            message.To.Add("nicoleapaflo02@gmail.com");
            message.Subject = "Demande de renouvellement";
            return View();
        }*/
        public ActionResult Imprimer()
        {
            var st = db.Stagiaires.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportSta.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Stagiaires.pdf");
        }
    }
}
