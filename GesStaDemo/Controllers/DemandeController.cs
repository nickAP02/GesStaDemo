using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using FluentEmail.Core;
using FluentEmail.Smtp;
using GesStaDemo;
using GesStaDemo.Models.Entities;

namespace GesStaDemo.Controllers
{
    public class DemandeController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Demande
        public ActionResult Index()
        {
            var demandes = db.Demandes.Include(d=>d.Offre);
            return View(demandes.ToList().GroupBy(d=>d.DateCreation));
        }

        // GET: Demande/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande demande = db.Demandes.Find(id);
            if (demande == null)
            {
                return HttpNotFound();
            }
            return View(demande);
        }

        // GET: Demande/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TypeDeStage = new SelectList(db.Offres, "OffreId", "LibOffre");
            return View();
        }

        // POST: Demande/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDem,DateCreation,Nom,Prenom,Sexe,DateNaissance,Nationalite,Telephone,Email,TypeDeStage,Accepter,CV")] Demande demande)
        {
            DateTime forbidDate = DateTime.Today.Date;
            System.Diagnostics.Debug.WriteLine(demande.DateNaissance.CompareTo(DateTime.Today));
            demande.DateCreation = DateTime.Today.Date;
            if (demande.DateNaissance==forbidDate)
            {
                ModelState.AddModelError("", "Veuillez choisir une date différente de la date d'aujourd'hui");
                return View(demande);
            }
            if(demande.DateNaissance.Year == DateTime.Now.Year)
            {
                ModelState.AddModelError("", "Veuillez choisir une année différente de l'année courante");
                return View(demande);
            }
            if (demande.DateNaissance.Year >= DateTime.Now.Year)
            {
                ModelState.AddModelError("", "Vous devez avoir au moins 18 ans");
                return View(demande);
            }
            var moydate = DateTime.Today.AddYears(-18);
            if (demande.DateNaissance <= DateTime.Today.AddYears(-1) && demande.DateNaissance >= moydate)
            {
                ModelState.AddModelError("", "Vous devez avoir au moins 18 ans");
                return View();
            }
            if (demande.CV == null)
            {
                ModelState.AddModelError("", "Le CV est obligatoire");
                return View(demande);
            }
            if (demande.Sexe == null)
            {
                ModelState.AddModelError("", "Le champ sexe est obligatoire");
                return View(demande);
            }
            var st = db.Database.SqlQuery<string>("select IdDem from Demande where Nom='" + demande.Nom + "'and  Prenom='" + demande.Prenom + "'and Telephone='" + demande.Telephone + "'and  Sexe='" + demande.Sexe + "'and Nationalite='" + demande.Nationalite + "'and Email='" + demande.Email + "'and DateNaissance='" + demande.DateNaissance + "'").FirstOrDefault();
            if (st != null)
            {
               ModelState.AddModelError("","Vous avez déjà une demande en cours !");
                return View();
            }  
            string filename = Path.GetFileName(demande.CV.FileName);
            var chemin = Server.MapPath("~/CV/") + filename;
            demande.Curriculum = filename;
            // db.Database.SqlQuery<string>("insert into Demande values('" + demande.Nom + "','" + demande.Prenom + "','" + demande.Sexe + "','" + "Convert(Date,demande.DateNaissance)" + "','" + demande.Nationalite + "','" + demande.Telephone + "','" + demande.Email + "','" + demande.TypeDeStage + "','" + "Convert(Date,demande.DebutStage)" + "','" + "Convert(Date,demande.FinStage)" + "','" + demande.Curriculum + "','" + demande.Accepter + "')");
            if (filename != null && filename.Length > 0 && Path.GetExtension(demande.CV.FileName) == ".pdf")
            {
                demande.CV.SaveAs(chemin);
                var stream = new StreamReader(chemin);
                
                var sender = new SmtpClient("smtp.gmail.com")
                {

                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("nicoleapaflo02@gmail.com", "nicoleapaflo02"),
                    EnableSsl = true
                };

                var message = new MailMessage();
                message.To.Add(demande.Email);
                message.From = new MailAddress("nicoleapaflo02@gmail.com");
                message.Subject = "Réception de demande de stage";
                //var duree = demande.Offre.FinStage.Subtract(demande.Offre.DebutStage);
                var quer = db.Database.SqlQuery<string>("select LibOffre from Offre where OffreId=" + demande.TypeDeStage + "").FirstOrDefault();
                System.Diagnostics.Debug.WriteLine(quer);
                var duree = db.Offres.Find(demande.TypeDeStage);
                var query = (duree.FinStage - duree.DebutStage).TotalDays;
                System.Diagnostics.Debug.WriteLine(duree);
                System.Diagnostics.Debug.WriteLine(query);
              
               if (demande.Sexe.StartsWith("F"))
               {
                    message.Body = "Madame " + demande.Nom + " " + demande.Prenom + " votre demande" + " pour le "+ quer.ToLower() +" d'une durée de "+ query +" jours"+ " a été reçue avec succès";
                    sender.Send(message);
               }
                else
                {
                    message.Body = "Monsieur " + demande.Nom + " " + demande.Prenom + " votre demande" + " pour le "+ quer.ToLower()  + " d'une durée de " + query + " jours" + " a été reçue avec succès";
                    sender.Send(message);
                }

                db.Database.ExecuteSqlCommand("insert into Demande values('" + demande.Nom+"','"+demande.Prenom+"','"+demande.Sexe+ "','" + demande.DateNaissance + "','" + demande.Nationalite+"','"+demande.Telephone+ "','" + demande.Email + "','"+demande.Curriculum+"',0,'" + demande.TypeDeStage +"','"+ demande.DateCreation +"')");
               // db.SaveChanges();
                return RedirectToAction("Index", "Offre");
            } 
            ViewBag.TypeDeStage = new SelectList(db.Offres, "OffreId", "LibOffre", demande.TypeDeStage);
            return RedirectToAction("Index", "Offre");
        }              
        

        // GET: Demande/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande demande = db.Demandes.Find(id);
            if (demande == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeDeStage = new SelectList(db.Offres, "OffreId", "LibOffre");
            return View(demande);
        }

        // POST: Demande/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDem,Nom,Prenom,Sexe,DateNaissance,Nationalite,Telephone,Email,TypeDeStage,Curriculum,Accepter")] Demande demande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeDeStage = new SelectList(db.Offres, "OffreId", "LibOffre");
            return View(demande);
        }

        // GET: Demande/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demande demande = db.Demandes.Find(id);
            if (demande == null)
            {
                return HttpNotFound();
            }
            return View(demande);
        }

        // POST: Demande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demande demande = db.Demandes.Find(id);
            db.Demandes.Remove(demande);
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
    }
}
