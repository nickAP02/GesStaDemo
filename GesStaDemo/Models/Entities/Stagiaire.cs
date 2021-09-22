using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    public class Stagiaire
    {
        public int IdSta { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string NomSta { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string PrenSta { get; set; }
        [Required(ErrorMessage = "Numero de téléphone obligatoire")]
        public string TelSta { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'email est obligatoire")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email invalide")]
        public string AdrSta { get; set; }
        public DateTime DebutStage { get; set; }
        public DateTime FinStage { get; set; }
        public int NbRenouvel { get; set; }
        [Required(ErrorMessage = "La valeur doit être différente de 0 et doit être une somme d'argent")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double Somm { get; set; }
        [Required(ErrorMessage = "Numero de téléphone obligatoire")]
        public string NatSta { get; set; }
        [Required(ErrorMessage = "Numero de téléphone obligatoire")]
        public string SexSta { get; set; }
        public DateTime DateNaisSta { get; set; }
        public virtual ICollection<Notation> Notations { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }
        public string CodRem { get; set; }
        public virtual ICollection<Remuneration> Remunerations { get; set; }
        public virtual ICollection<SortirDe> SortirDes { get; set; }
        public virtual ICollection<AvoirPour> AvoirPours { get; set; }
        public int IdProv { get; set; }
        public virtual Provenance Provenance { get; set; }
        public virtual ICollection<Utiliser> Utilisers { get; set; }
        public int UtilId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

    }
    
}