using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Theme
    {
        /*public Theme()
        {
            MaitreDeStages = new HashSet<MaitreDeStage>();
            Stagiaires = new HashSet<Stagiaire>();
        }*/
        public int IdThe { get; set; }
        public DateTime DateTheme { get; set; }
        public string LibTheme { get; set; }
        public string Objectifs { get; set; }
        public int CodMS { get; set; }
        public virtual MaitreDeStage MaitreDeStage{ get; set; }
        public int IdSta { get; set; }
        public virtual Stagiaire Stagiaire { get; set; }
    }
}