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
            Property(s => s.IdSup)
                .HasColumnName("Id_Sup")
                .IsRequired();
            Property(s => s.NomSup)
                .HasColumnName("Nom_Sup")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(s => s.PrenSup)
                .HasColumnName("Prenom_Sup")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(s => s.AdrSup)
                .HasColumnName("Adresse_Sup")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(s => s.TelSup)
                .HasColumnName("Telephone_Sup")
                .HasColumnType("varchar")
                .HasMaxLength(7)
                .IsRequired();
        }
  }
}