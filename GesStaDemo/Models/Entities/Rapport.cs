using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Rapport
    {
        public string CodRapp { get; set; }
        public string NomRapp { get; set; }
        public string Taches { get; set; }
        public DateTime DatePresentat { get; set; }
       
        public virtual ICollection<Notation> Notations { get; set; }
    }
}