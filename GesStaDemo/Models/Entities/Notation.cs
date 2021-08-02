using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Notation
    {
        public int NotRapp { get; set; }
        public string ObserEval { get; set; }
        public DateTime DateNot { get; set; }
        public virtual ICollection <Stagiaire> Stagiaires { get; set; }
        public virtual ICollection<MaitreDeStage> MaitreDeStages { get; set; }
        public virtual ICollection<Rapport> Rapports { get; set; }
    }
}