using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Notation
    {
        public int IdNot { get; set; }
        public int NotRapp { get; set; }
        public string ObserEval { get; set; }
        public DateTime DateNot { get; set; }
        public int IdSta { get; set; }
        public virtual Stagiaire Stagiaire { get; set; }
        public int CodMS { get; set; }
        public virtual MaitreDeStage MaitreDeStage { get; set; }
        public string CodRapp { get; set; }
        public virtual Rapport Rapport { get; set; }
    }
}