using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class MaitreDeStage
    {
        public string CodMS { get; set; }
        public string NomMS { get; set; }
        public string PrenMS { get; set; }
        public string TelMS { get; set; }
        public string AdrMS { get; set; }
        public string Fonction{ get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Notation> Notations { get; set; }
    }
}