using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Provenance
    {
        public int IdProv { get; set; }
        public string LibProv { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Email invalide")]
        public string AdrProv { get; set; }
        public string VilleProv { get; set; }
        public virtual ICollection<SortirDe> SortirDes { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}