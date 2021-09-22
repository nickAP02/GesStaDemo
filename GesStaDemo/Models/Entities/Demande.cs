using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.Entities
{
    [Table("Demande")]
    public class Demande
    {
        [Key]
        public int IdDem { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Nationalite { get; set; }
        [Required(ErrorMessage ="Numero de téléphone obligatoire")]
        public string Telephone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'email est obligatoire")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email invalide")]
        public string Email { get; set; }
        public int TypeDeStage { get; set; }
        public virtual Offre Offre { get; set; }
        [Required(ErrorMessage = "CV obligatoire, doit être en Pdf")]
        [FileExtensions(Extensions = ".Pdf", ErrorMessage = "Le CV doit être en Pdf")]
        [Display(Name ="CV")]
        public string Curriculum { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase CV { get; set; }
        public int Accepter { get; set; }
        public DateTime DateCreation { get; set; }
    }
}