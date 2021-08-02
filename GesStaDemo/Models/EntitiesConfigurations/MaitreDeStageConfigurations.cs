using GesStaDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GesStaDemo.Models.EntitiesConfigurations
{
   class MaitreDeStageConfigurations : EntityTypeConfiguration<MaitreDeStage>
    {
        public MaitreDeStageConfigurations()
        {
            ToTable("MaitreDeStage");
            Property(m => m.CodMS)
                .HasColumnName("Code_MS")
                .HasColumnType("varchar")
                .HasMaxLength(18)
                .IsRequired();
            Property(m => m.NomMS)
                .HasColumnName("Nom_MS")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(m => m.PrenMS)
                .HasColumnName("Prenom_MS")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();
            Property(m => m.TelMS)
                .HasColumnName("Telephone_MS")
                .HasColumnType("varchar")
                .HasMaxLength(7)
                .IsRequired();
            Property(m => m.AdrMS)
                .HasColumnName("Adresse_MS")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(m => m.Fonction)
                .HasColumnName("Fonction_MS")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            HasMany(m => m.Sections);
            HasMany(m => m.Notations);
            HasMany(m => m.Themes);
        }
    }
}