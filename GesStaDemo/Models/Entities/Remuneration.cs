using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Remuneration
    {
        public string CodRem { get; set; }
        [Required(ErrorMessage ="La valeur doit être différente de 0 et doit être une somme d'argent")]
        public decimal RegleMens 
        { get; set; }

        public DateTime DateRemiz { get; set; }
        public int IdSta { get; set; }
        public virtual Stagiaire Stagiaire { get; set; }

    }
}