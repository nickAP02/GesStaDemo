using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Section
    {
        /*public Section()
        {
            Formations = new HashSet<Formation>();
            Divisions = new HashSet<Division>();
            //Formations = new HashSet<Formation>();
        }*/
        public string CodSec { get; set; }
        public string LibSec { get; set; }
        public string ActSec { get; set; }
       
        public virtual ICollection<MaitreDeStage> MaitreDeStages { get; set; }
        public string CodDiv { get; set; }
        public virtual Division Division { get; set; }
        //public int IdFor { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }
    }
}