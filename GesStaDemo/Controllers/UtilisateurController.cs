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
    public class UtilisateurController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();

        // GET: Utilisateur
        public ActionResult Index()
        {
            return View(db.Utilisateurs.ToList());
        }

        // GET: Utilisateur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateur/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UtilId,Login,Passwd,Photo,Image")] Utilisateur utilisateur)
        {
           System.Diagnostics.Debug.WriteLine(utilisateur.Image.FileName);
            string filename = Path.GetFileName(utilisateur.Image.FileName);
            utilisateur.Photo = filename;
            utilisateur.Image.SaveAs(Path.Combine(Server.MapPath("~/Images/")) + filename);
            var stream = new StreamReader(Path.Combine(Server.MapPath("~/Images/")) + filename);
            if (filename != null && filename.Length > 0 && Path.GetExtension(utilisateur.Image.FileName) == ".jpg")
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index", "Utilisateur");
            }  
            else
            {
                ModelState.AddModelError("", "Veuillez choisir une image");
                return View(utilisateur);
            }
            
        }

        // GET: Utilisateur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateur/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UtilId,Login,Passwd,Photo,Image")] Utilisateur utilisateur)
        {
            string filename = Path.GetFileName(utilisateur.Image.FileName);
            utilisateur.Photo = filename;
            utilisateur.Image.SaveAs(Path.Combine(Server.MapPath("~/Images/")) + filename);
            var stream = new StreamReader(Path.Combine(Server.MapPath("~/Images/")) + filename);
            if (filename != null && filename.Length > 0 && Path.GetExtension(utilisateur.Image.FileName) == ".jpg")
            {
                if (ModelState.IsValid)
                {
                    db.Entry(utilisateur).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("", "Veuillez choisir une image");
                return View(utilisateur);
            }
            return View(utilisateur);
        }

        // GET: Utilisateur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateur);
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
            var st = db.Utilisateurs.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportUser.rpt")));
            rd.SetDataSource(st);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Utilisateurs.pdf");
        }
    }
}
