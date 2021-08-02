using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class NoteDeService
    {
        public string CodNotSer{ get; set; }
        public string Objet { get; set; }
        public DateTime DateSignat { get; set; }
        public int Duree { get; set; }
        public DateTime DateDebut { get; set; }
        public Boolean Remunerer { get; set; }
    }

}