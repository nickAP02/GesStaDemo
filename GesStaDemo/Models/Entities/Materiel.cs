using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Materiel
    {
        public string CodMat { get; set; }
        public string LibMat { get; set; }
        public int QuantMat { get; set; }
        public string Caracteristik { get; set; }
        public ICollection<Utiliser> Utilisers { get; set; }
        public int Disponible { get; set; }
    }
}