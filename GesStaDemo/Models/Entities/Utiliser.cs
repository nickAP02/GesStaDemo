using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Utiliser
    {
        public int Id { get; set; }
        public DateTime DateEmp { get; set; }
        public DateTime DateRet { get; set; }
        public int IdSta { get; set; }
        public virtual Stagiaire Stagiaire { get; set; }
        public string CodMat { get; set; }
        public virtual Materiel Materiel { get; set; }
    }
}