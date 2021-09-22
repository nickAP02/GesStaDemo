using GesStaDemo.Filters;
using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GesStaDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private GesStaDbContext quer = new GesStaDbContext();
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult About()
        {
            return View();
        }

        
        /*[HttpGet]
        public ActionResult Demande()
        {
            return View();
        }
        [HandleError]
        [HttpPost]
        public ActionResult Demande(Demande sa)
        {

            /*using (quer)
            {
              
                //if(sa.Curriculum.Length >0)
                //{
                    //obtention du CV sans l'extension
                   // var Cv = Path.GetFileName(sa.Curriculum);
                //obtention du CV de l'extension 
                 //var chemin = ConfigurationManager.AppSettings["CV"];
                    //obtention de la date 
                    // Cv = DateTime.Now.ToString("AAAAmmmm") + "-" + Cv.Trim() + FileExtension;
                    //le fichier est renvoyé dans les configurations
                    // string curriculum = ConfigurationManager.AppSettings["CV"].ToString();
                    //reconstitution du chemin
                    //sa.Curriculum = curriculum + Cv;
                    //sauvegarde avec l'extension et le nom
               // sa.CV.SaveAs(chemin);


               // }
               
                if (ModelState.IsValid)
                {*/

            // vérification de la table demande pour s'assurer que la demande n'existe pas déjà
                       /* var st = quer.Database.SqlQuery<string>("select Nom,Prenom,Telephone,DebutStage,FinStage,Sexe,Nationalite,Email,DateNaissance from Demande where Nom='"+ sa.Nom +"'and  Prenom='"+ sa.Prenom +"'and Telephone='"+ sa.Telephone +"'and  DebutStage='"+ sa.DebutStage +"'and  FinStage ='"+ sa.FinStage +"'and  Sexe='"+ sa.Sexe +"'and  Nationalite='"+ sa.Nationalite +"'and Email='"+ sa.Email +"'and DateNaissance='"+ sa.DateNaissance + "").Distinct();
                        if (st != null)
                        {
                            ModelState.AddModelError("", "Vous avez déjà enregistré une demande !");
                            return View();
                        }
                        else
                        {
                            //la demande est acceptée, un email est envoyé au demandeur
                            try
                            {
                                SmtpClient sender = new SmtpClient();

                                /*var message = new MailMessage();
                                Demande dem = new Demande();
                                dem.Curriculum = sa.Curriculum;
                                dem.Add(sa);
                                quer.Demandes.Add(sa);
                                if (sa.Curriculum.Length > 0)
                                {
                                var Cv = Path.GetFileNameWithoutExtension(sa.CV.FileName);
                                var Extension = Path.GetExtension(sa.CV.FileName);
                                var chemin = ConfigurationManager.AppSettings["CvEnvoye"].ToString();
                                sa.Curriculum = chemin + Cv;    
                                sa.CV.SaveAs(sa.Curriculum);
                            
                                    /*var message = new MailMessage();
                                    //quer.Demandes.Add(sa);
                                    message.To.Add(sa.Email);
                                    message.From = new MailAddress("nicoleapaflo02@gmail.com");
                                    message.Subject = "Réception de demande de stage";
                                    try
                                    {*/



                                    /*  if (sa.Sexe.StartsWith("F"))
                                      {
                                          message.Body = "Madame" + sa.Nom + " " + sa.Prenom + "votre demande pour cette offre de stage a été reçue avec success";
                                          sender.Send(message);
                                      }
                                      else
                                      {
                                          message.Body = "Monsieur" + sa.Nom + " " + sa.Prenom + "votre demande pour cette offre de stage a été reçue avec success";
                                          sender.Send(message);
                                      }
                                    quer.Demandes.Add(sa);
                                    quer.SaveChanges();
                                        return RedirectToAction("Index", "Home");
                                    }

                                    catch (Exception e)
                                    {
                                        e.ToString();
                                    }
                                }
                            }
                            catch (DbEntityValidationException ex)
                            {
                                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                                {
                                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                                    {
                                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                    }
                                }
                            }
                        }

               // }
                  

            //}
                
            return View();

        }*/

        private Exception HttpUnhandledException()
        {
            throw new NotImplementedException();
        }
        
        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Acces non autorisé";

            return View();
        }
        
        public ActionResult Error()
        {
            return View();
        }
    }
}
