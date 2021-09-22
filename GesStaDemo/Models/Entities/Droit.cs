using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;


namespace GesStaDemo.Models.Entities
{
    public class Droit
    {
        public int DroitId { get; set; }
        public int UtilId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public int ProfilId { get; set; }
        public virtual Profil Profil { get; set; }
    }
}
