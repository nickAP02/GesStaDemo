using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Utiliser
    {
        public DateTime DateEmp { get; set; }
        public DateTime DateRet { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
        public virtual ICollection<Materiel> Materiels { get; set; }
    }
}