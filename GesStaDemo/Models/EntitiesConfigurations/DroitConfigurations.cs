using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
    public class DroitConfigurations : EntityTypeConfiguration<Droit>
    {
        public DroitConfigurations()
        {
            ToTable("Droit");
            HasKey(d => d.DroitId);
            HasRequired(p => p.Utilisateur)
                .WithMany(d=>d.Droits)
                .HasForeignKey(u=>u.UtilId);
            HasRequired(p => p.Profil)
                .WithMany(d => d.Droits)
                .HasForeignKey(p => p.ProfilId);
                
        }
    }
}