using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Section
    {
        public string CodSec { get; set; }
        public string LibSec { get; set; }
        public string ActSec { get; set; }
        public virtual ICollection<MaitreDeStage> MaitreDeStages { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }
    }
}