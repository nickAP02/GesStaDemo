using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class MaitreDeStage
    {
        public int CodMS { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string NomMS { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string PrenMS { get; set; }
        [Required(ErrorMessage = "Numero de téléphone obligatoire")]
        public string TelMS { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'email est obligatoire")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email invalide")]
        public string AdrMS { get; set; }
        public string Fonction{ get; set; }
        public string CodSec { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Notation> Notations { get; set; }
        public int UtilId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}