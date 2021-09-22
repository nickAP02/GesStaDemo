using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Superviseur
    {
        public int IdSup { get; set; }

        [Required(ErrorMessage="Ce champ est obligatoire")]
        public string NomSup { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string PrenSup { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'email est obligatoire")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email invalide")]
        public string AdrSup { get; set; }
        [Required(ErrorMessage = "Numero de téléphone obligatoire")]
        public string TelSup { get; set; }
        public ICollection<AvoirPour> AvoirPours { get; set; }
        public int UtilId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}