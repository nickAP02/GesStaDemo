using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GesStaDemo.Models.Entities
{
    [Table("Profil")]
    public partial class Profil 
    {
        [Key]
        public int ProfilId { get; set; }

        [Required]
        [StringLength(20)]
        public string LibProfil { get; set; }
        public ICollection<Droit> Droits { get; set; }
    }
}
