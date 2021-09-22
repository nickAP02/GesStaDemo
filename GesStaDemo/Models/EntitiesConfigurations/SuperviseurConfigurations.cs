using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
  class SuperviseurConfigurations : EntityTypeConfiguration<Superviseur>
  {
      public SuperviseurConfigurations()
      {
            ToTable("Superviseur");
            HasKey(k => k.IdSup);
            Property(s => s.NomSup)
                .HasColumnName("Nom")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(s => s.PrenSup)
                .HasColumnName("Prenom")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(s => s.AdrSup)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(s => s.TelSup)
                .HasColumnName("Telephone")
                 .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();
            HasMany(s => s.AvoirPours);
            HasRequired(u => u.Utilisateur)
                 .WithMany(s => s.Superviseurs)
                 .HasForeignKey(u => u.UtilId)
                 .WillCascadeOnDelete(false); 
        }
  }
}