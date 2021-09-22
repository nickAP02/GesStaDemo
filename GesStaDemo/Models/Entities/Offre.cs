using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Offre
    {
        public int OffreId { get; set; }
        public string LibOffre { get; set; }
        public DateTime DebutStage { get; set; }
        public DateTime FinStage { get; set; }
        public bool Remunerer { get; set; }
        public ICollection<Demande> Demandes { get; set; }
    }
}