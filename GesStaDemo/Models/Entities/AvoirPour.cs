using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class AvoirPour
    {
      /* public AvoirPour()
        {
            Superviseurs = new HashSet<Superviseur>();
            Stagiaires = new HashSet<Stagiaire>();
        }*/
        public int Id { get; set; }
        public DateTime DateSup { get; set; }
        public int AvoirPourSup { get; set; }
        public virtual Stagiaire Stagiaire { get; set; }
        public int AvoirPourSta { get; set; }
        public virtual Superviseur Superviseur { get; set; }
        
    }
}