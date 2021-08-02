using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Direction
    {
        public string CodDir{ get; set; }
        public string LibDir { get; set; }
        public string ActDir { get; set; }
        public virtual ICollection<Division> Divisions { get; set; }
    }
}