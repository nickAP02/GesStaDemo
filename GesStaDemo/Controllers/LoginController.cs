using GesStaDemo.Filters;
using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GesStaDemo.Models;

namespace GesStaDemo.Controllers
{
    
    public class LoginController : Controller
    {
        private GesStaDbContext db = new GesStaDbContext();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utilisateur util, string returnUrl)
        {

            var quer = new GesStaDbContext();
               
            var queryString = quer.Database.SqlQuery<string>("select p.LibProfil from Profil as p join Droit as d on p.ProfilId = d.ProfilId join Utilisateur as u on d.UtilId = u.UtilId where Login='"+ util.Login +"'and Passwd='" +util.Passwd+ "'").FirstOrDefault();
            var utilisateur = Convert.ToString(queryString);

            if (queryString != null)
            {
                Session["Login"] = util.Login;
                Session["Passwd"] = util.Passwd;
                switch (utilisateur)
                {
                    case "Admin":

                        return RedirectToAction("Admin", "Admin");
                        break;
                    case "Sta":
                    {
                        var utilisateurID = quer.Database.SqlQuery<int>("select UtilId from Utilisateur where Login='" + util.Login+ "' and Passwd='" + util.Passwd + "'").FirstOrDefault();
                        var stagiaireID = quer.Database.SqlQuery<int>("select IdSta from Stagiaire where UtilId='"+Convert.ToString(utilisateurID)+"'").FirstOrDefault();
                        Session["IdSta"] = stagiaireID;
                            
                        return RedirectToAction("Stagiaire", "Login");
                    }
                        break;
                    case "MS":
                        return RedirectToAction("MaitreDeStage", "Login");
                        break;
                    case "Sup":

                        return RedirectToAction("Superviseur", "Login");
                        break;
                    default:

                        return RedirectToAction("Index", "Home");
                        break;
                }
                        
            }
            else
            {
                for (int i = 0; i < 3;i++)
                {
                    if (util.Login == null && util.Passwd == null)
                    {
                        ModelState.AddModelError("", "Vous n'avez pas de compte utilisateur");
                        return View();
                    }
                    if (util.Login == null|| util.Passwd == null)
                    {
                        ModelState.AddModelError("", "Mot de passe ou login incorrect ");
                        return View(util);
                    }

                   /* ModelState.AddModelError("", "Veuillez réessayer");
                    return View();*/
                }
                /*ModelState.AddModelError("", "Echec de trois tentatives, réessayez plus tard");
                return View();*/
            }
            
            return View(util);
        }
        public ActionResult Deconnexion()
        {
               FormsAuthentication.SignOut();
               Session["Login"] = string.Empty;
               Session["Passwd"] = string.Empty;
               return RedirectToAction("Index", "Offre");
        }
        
      
        [Authentication_Filter]
        public ActionResult Stagiaire()
        {
            return View();
        }
        [Authentication_Filter]
        public ActionResult Superviseur()
        {
            //var avoirsta = db.Database.SqlQuery<string>("select NomSta,PrenSta from Stagiaire as s join AvoirPour as a on s.IdSta=a.AvoirpourSup");
            return View();
        }
        [Authentication_Filter]
        public ActionResult MaitreDeStage()
         {
            return View();
        }


    }
}