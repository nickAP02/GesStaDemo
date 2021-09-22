using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GesStaDemo.Filters
{
    public class Authorization_Filter : AuthorizeAttribute
    {
         private readonly string[] ProfilUtilisateurs;

         public Authorization_Filter(params string[] droits)
         {
             this.ProfilUtilisateurs = droits;
         }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
             bool verif = false;
             var login = Convert.ToString(httpContext.Session["Login"]);
             if(!string.IsNullOrEmpty(login))
                 using ( var context = new GesStaDbContext())
                 {
                    var role = context.Database.SqlQuery<string>("select LibProfil from Profil as p join Droit as d on p.Profilid=d.ProfilId join Utilisateur as u on u.UtilId where u.Login="+login+"").FirstOrDefault();
                        
                      foreach(var droit in ProfilUtilisateurs)
                      {
                         if (droit == role) return true;
                      }

                 }

                return verif;
        }
        /*public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

        }*/
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) 
        { 
            filterContext.Result = new RedirectToRouteResult(
                
            new RouteValueDictionary
            {
                { "controller" , "Home" },
                { "action" , "UnAuthorized" }

            });
        
        }
    }
}