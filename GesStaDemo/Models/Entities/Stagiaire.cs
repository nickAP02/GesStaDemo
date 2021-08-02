using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Stagiaire
    {
        public int IdSta;
        public string NomSta { get; set; }
        public string PrenSta { get; set; }
        public string TelSta { get; set; }
        public string AdrSta { get; set; }
        public DateTime FinStage { get; set; }
        public int NbRenouvel { get; set; }
        public int Somm { get; set; }
        public string NatSta { get; set; }
        public char SexSta { get; set; }
        public DateTime DateNaisSta { get; set; }
        public virtual ICollection<Notation> Notations { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }
        public virtual ICollection<NoteDeService> NoteDeServices { get; set; }
        public virtual ICollection<Remuneration> Remunerations { get; set; }
    }
    
}