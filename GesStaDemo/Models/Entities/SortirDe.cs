using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class SortirDe
    {
      
         public int Id { get; set; }
        public DateTime DatePro { get; set; }
        public string NivoEtude { get; set; }
        public int IdSta { get; set; }
        public virtual Stagiaire Stagiaire { get; set; }
        public int IdProv { get; set; }
        public virtual Provenance Provenance { get; set; }
    }
}