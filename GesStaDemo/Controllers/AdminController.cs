using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mime;
using System.Web.UI.WebControls;
using GleamTech.AspNet.Mvc;using GleamTech.DocumentUltimate;
using GleamTech.DocumentUltimate.AspNet;
using GleamTech.DocumentUltimate.AspNet.UI;
using System.IO;
using System.Dynamic;
using System.Data.Entity.Core;
using GesStaDemo.Filters;
using CrystalDecisions.CrystalReports.Engine;

namespace GesStaDemo.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private GesStaDbContext db = new GesStaDbContext();
        [Authentication_Filter]
        public ActionResult Admin()
        {
            ViewBag.Division = db.Divisions.Count();
            ViewBag.Direction = db.Directions.Count();
            ViewBag.Section = db.Sections.Count();
            ViewBag.MaitreDeStage = db.MaitreDeStages.Count();
            ViewBag.Stagiaire = db.Stagiaires.Count();
            ViewBag.Superviseur = db.Superviseurs.Count();
            ViewBag.Formation = db.Formations.Count();
            ViewBag.Remuneration = db.Remunerations.Count();
            ViewBag.Demande = db.Demandes.Count();
            ViewBag.Offre = db.Offres.Count();
            ViewBag.Utilisateur = db.Utilisateurs.Count();
            ViewBag.Rapport = db.Rapports.Count();
            ViewBag.Notation = db.Notations.Count();
            return View();
        }
        public ActionResult Liste()
        {
            return View(db.Offres.ToList());
        }
        public ActionResult Demandes()
        {
            ViewBag.Rech = db.Database.ExecuteSqlCommand("select * from Demande");
            var demandes = db.Demandes;
            return View(demandes.ToList());
        }
      
        public ActionResult Voir(int ?id)
         {
            var filename = db.Database.SqlQuery<string>("select Curriculum from Demande where IdDem="+id+"").FirstOrDefault();
            // file = new FileStream(("'"+filename+"'"), FileMode.Append);
            //StreamReader stream = new StreamReader("'"+filename+"'");
           
            var file = new FileStream(Path.Combine(Server.MapPath("~/CV/")) + filename, FileMode.Open, FileAccess.Read, FileShare.Read, 128, FileOptions.RandomAccess);
            var fs = new FileStreamResult(file, "application/pdf");    
            

            var viewer = new DocumentViewer
            {
                    Width = 800,
                    Height = 1000,
                    Resizable = true,
                    DisplayLanguage = "fr-FR",
                    
                   // Document = @"" + file+ "",
                DocumentSource = new DocumentSource(
                new DocumentInfo(filename, filename),
                new StreamResult(file))
            };
            return View(viewer);
            
         }
        [HttpGet]
        public ActionResult Valider() 
        {
            ViewBag.ProfilId = new SelectList(db.Profils, "ProfilId", "LibProfil");
            //ViewBag.UtilId = new SelectList(db.Utilisateurs,"UtilId","Login");
            return View();
        }
        [HttpPost]
        public ActionResult Valider([Bind(Include = "UtilId,Login,Passwd,Photo,Image")]int ? id, Valider val)
        {

            var Email = db.Database.SqlQuery<string>("select Email from Demande where IdDem='" + id + "' and Accepter=0").FirstOrDefault();
            var stage = db.Database.SqlQuery<string>("select LibOffre from Demande join Offre on OffreId=TypeDeStage where IdDem='" + id +"'").FirstOrDefault();
             var sender = new SmtpClient("smtp.gmail.com")
             {

                 UseDefaultCredentials = false,
                 Port = 587,
                 Credentials = new NetworkCredential("nicoleapaflo02@gmail.com", "nicoleapaflo02"),
                 EnableSsl = true
             };


             var message = new MailMessage();
             message.To.Add(Email);
             message.From = new MailAddress("nicoleapaflo02@gmail.com");
             message.Subject = "Acceptation de demande de stage";

             message.Body = "Votre demande pour le "+stage.ToLower()+" a été acceptée " + "vous trouverez ci-dessous vos identifiants de connexion"+"\n"+ 
                "Nom d'utilisateur : " + val.Utilisateur.Login + ", mot de passe : " + val.Utilisateur.Passwd;
             //message.Attachments(val, "/application/pdf");
             //var conv = new DocumentConverter(file, DocumentFormat.Pdf);
             //System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(Server.MapPath("~/Views/Admin/") + "Admin.cshtml", MediaTypeNames.Application.Pdf);
             //var attach = new System.Net.Mail.Attachment("Nom d'utilisateur :"+val.Utilisateur.Login+", mot de passe :"+val.Utilisateur.Login,"application/pdf");
             //System.Diagnostics.Debug.WriteLine(attach);
             //System.Diagnostics.Debug.WriteLine(conv);
             //message.Attachments.Add(attach);
             try
             {

                 sender.Send(message);
             }
             catch (Exception e)
             {
                 e.ToString();
             }

            string filename = Path.GetFileName(val.Utilisateur.Image.FileName);
            val.Utilisateur.Photo = filename;
            val.Utilisateur.Image.SaveAs(Path.Combine(Server.MapPath("~/Images/")) + filename);
            var stream = new StreamReader(Path.Combine(Server.MapPath("~/Images/")) + filename);

            // db.Database.SqlQuery<string>("select Photo from Utilisateur where Photo =' ' update set Photo='Image/img1.jpg' where Photo=' '");
            //db.Database.ExecuteSqlCommand("insert into Utilisateur values('" + val.Utilisateur.Login + "','" + val.Utilisateur.Passwd + "','" +val.Utilisateur.Photo+"')");
            //var q = db.Database.SqlQuery<string>("select UtilId from Utilisateur where Login='" + val.Utilisateur.Login + "'and Passwd= '"+ val.Utilisateur.Passwd +"'").FirstOrDefault();
            //db.Database.ExecuteSqlCommand("insert into Droit values('" + q + "','" +'2'+"')");
            if (filename != null && filename.Length > 0 && Path.GetExtension(val.Utilisateur.Image.FileName) == ".jpg")
            {
                db.Utilisateurs.Add(val.Utilisateur);
                db.SaveChanges();
            }  
            
            var setAccept = db.Database.SqlQuery<string>("select Email from Demande where IdDem='" + id + "' and Accepter=0 update Demande set Accepter=1 where IdDem='" + id + "'").FirstOrDefault();
           return RedirectToAction("Accepter", "Admin");
            
        }
        public ActionResult Envoyer(int ?id)
         {
             var Email = db.Database.SqlQuery<string>("select Email from Stagiaire where IdSta='" + id +"' ").FirstOrDefault();

             var sender = new SmtpClient("smtp.gmail.com")
             {

                 UseDefaultCredentials = false,
                 Port = 587,
                 Credentials = new NetworkCredential("nicoleapaflo02@gmail.com", "nicoleapaflo02"),
                 EnableSsl = true
             };

            var email = Convert.ToString(Email);
             var message = new MailMessage();
             message.To.Add(email.ToString());
             message.From = new MailAddress("nicoleapaflo02@gmail.com");
             message.Subject = "Acceptation de renouvellement de stage";

             message.Body = "Votre demande de renouvelement de stage a été acceptée";
             try
             {

                 sender.Send(message);
             }
             catch (Exception e)
             {
                 e.ToString();
             }
            return View();
         }
        public ActionResult Accepter()
        { 

            var acceptees = db.Demandes.SqlQuery("select * from Demande where Accepter=1").ToList();
            return View(acceptees);

        }
        [HttpGet]
        public ActionResult Refuser()
        {

            var setRefus = db.Demandes.SqlQuery("select * from Demande where Accepter=2");
            var refusees = setRefus.ToList();
            return View(refusees);
        }
        [HttpPost]
        public ActionResult Refuser(int ?id)
        {
             var sender = new SmtpClient("smtp.gmail.com")
             {

                 UseDefaultCredentials = false,
                 Port = 587,
                 Credentials = new NetworkCredential("nicoleapaflo02@gmail.com", "nicoleapaflo02"),
                 EnableSsl = true
             };
             var Email = db.Database.SqlQuery<string>("select Email from Demande where IdDem='" + id + "'and Accepter=0").FirstOrDefault();
             var email = Convert.ToString(Email);
             var message = new MailMessage();
             message.To.Add(email);
             message.From = new MailAddress("nicoleapaflo02@gmail.com");
             message.Subject = "Refus de demande de stage";
            var stage = db.Database.SqlQuery<string>("select LibOffre from Demande join Offre on OffreId=TypeDeStage where IdDem = '" + id + "'").FirstOrDefault();
             message.Body = "Votre demande"+" pour le "+stage.ToLower()+ " a été refusée";
             sender.Send(message);
            var setRefus = db.Database.SqlQuery<string>("select Email from Demande where IdDem= '"+id+"' and Accepter=0  update Demande set Accepter=2 where IdDem='" + id +"'").FirstOrDefault();
            var refusees = setRefus.ToList();
            return RedirectToAction("Refuser", "Admin");
        }
        public ActionResult ImprimerDemandes()
        {
            var dem = db.Demandes.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportDemande.rpt")));
            rd.SetDataSource(dem);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Demandes.pdf");
        }
        public ActionResult Acceptees()
        {
            var acceptees = db.Demandes.SqlQuery("select * from Demande where Accepter=1").ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportAccept.rpt")));
            rd.SetDataSource(acceptees);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Acceptations.pdf");
        }
        public ActionResult Refus()
        {
            var refusees = db.Database.SqlQuery<string>("select * from Demande where Accepter=2").ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportRefus.rpt")));
            rd.SetDataSource(refusees);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Refus.pdf");
        }
        public ActionResult Offres()
        {
            var offres = db.Offres.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/ReportOffre.rpt")));
            rd.SetDataSource(offres);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Offres.pdf");
        }
    }

}