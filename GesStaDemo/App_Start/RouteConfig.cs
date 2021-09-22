using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GesStaDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Offre", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url:"{controller}/{action}/{id}",
                defaults: new {controller = "Login", action ="Login", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Postuler",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Demande", action = "Demande", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Admin", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Direction",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Direction", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Division",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Division", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Formation",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Formation", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "MaitreDeStage",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "MaitreDeStage", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Materiel",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Materiel", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "Notation",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Notation", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
              name: "NoteDeService",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "NoteDeService", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "Provenance",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Provenance", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
               name: "Rapport",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Rapport", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "Section",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Section", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
               name: "Stagiaire",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Stagiaire", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Superviseur",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Superviseur", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
            name: "Theme",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Theme", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
           name: "Reception",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "FluentEmail", action = "Reception", id = UrlParameter.Optional }
          );
            routes.MapRoute(
            name: "Demandes",
            url :"{controller}/{action}/{id}",
            defaults: new {controller = "Admin" , action = "Demandes" , id = UrlParameter.Optional }
                );
        }
    }
}
