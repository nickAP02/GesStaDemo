using FluentEmail.Smtp;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using FluentEmail.Core;
using System.Threading.Tasks;

namespace GesStaDemo.Controllers
{
    public class FluentEmailController : Controller
    {
        // GET: FluentEmail
        public async Task <ActionResult> Reception(IFluentEmail mailer)
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
             {

                 UseDefaultCredentials = false,
                 Port = 587,
                 Credentials = new NetworkCredential("nicoleapaflo02@gmail.com", "nicoleapaflo02"),
                 EnableSsl = true
             }); ;
             Email.DefaultSender = sender;

             var email = Email
                 .From("nicoleapaflo02@gmail.com", "Nick")
                 .To("borisdalt@gmail.com", "Boris")
                 .Subject("Confirmation d'envoi de demande")
                 .Body("Votre demande de stage a été reçue!");

             try
             {

                 await email.SendAsync();
             }
             catch(Exception e)
             {
                 e.ToString();
             }
           /* using(var db = new GesStaDbContext())
            {
                var Demandes = db.Postulers.ToList();
                var adresses = Demandes.Distinct()
                foreach(var adresse in Demandes)
                {

                }
            } */

            return RedirectToAction("Index","Home");
        }
    }
}