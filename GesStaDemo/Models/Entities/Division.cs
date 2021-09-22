using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Division
    {
        /*public Division()
        {
            Sections = new HashSet<Section>();
        }*/

        public string CodDiv { get; set; }
        public string LibDiv { get; set; }
        public string ActDiv { get; set; }
       // public string CodSec { get; set; }
        public string CodDir { get; set; }
        public virtual Direction Direction { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}