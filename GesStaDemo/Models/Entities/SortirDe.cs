using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class SortirDe
    {
        public DateTime DatePro { get; set; }
        public string NivoEtude { get; set; }
        public virtual ICollection<Provenance> Provenances { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}