using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Formation
    {
        public DateTime DateAffectation { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
        public virtual ICollection <Section> Sections { get; set; }
    }
}