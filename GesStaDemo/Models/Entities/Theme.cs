using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Theme
    {
        public DateTime DateTheme { get; set; }
        public string LibTheme { get; set; }
        public string Objectifs { get; set; }
        public virtual ICollection<MaitreDeStage> MaitreDeStages { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}