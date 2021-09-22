using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GesStaDemo.Models.Entities
{
   
    public class Utilisateur
    {
        public int UtilId { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Passwd { get; set; }
        [Required]
       
        public string Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image { get; set; }
        public virtual ICollection<Droit> Droits { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
        public virtual ICollection<MaitreDeStage> MaitreDeStages { get; set; }
        public virtual ICollection<Superviseur> Superviseurs { get; set; }
    }
}
