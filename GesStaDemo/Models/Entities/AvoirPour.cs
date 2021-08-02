using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class AvoirPour
    {
        public DateTime DateSup { get; set; }
        public virtual ICollection<Superviseur> Superviseurs { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}