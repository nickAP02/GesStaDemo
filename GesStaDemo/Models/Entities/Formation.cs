using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Formation
    {
        public int  IdFor{ get; set; }
        public DateTime DateAffectation { get; set; }
        public int IdSta { get; set; }
        public virtual Stagiaire Stagiaire { get; set; }
        public string CodSec { get; set; }
        public virtual Section Section { get; set; }
    }
}